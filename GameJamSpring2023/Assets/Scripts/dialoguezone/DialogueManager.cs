using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Image characterSprite;
    public Button continueButton;
    public Button dialogueButton;
    public Button loadNextScene;
    public AudioSource characterVoice;
    public Image background;

    public DialogueHead[] conversationHeads;
    public Dialogue startConversation;
    public CharacterSO[] characters;
    public Queue<Dialogue> startConvos;


    private Queue<string> sentences;
    private Dialogue currDialogue;

    private GameManager gameManager;


    private void Awake()
    {
        sentences = new Queue<string>();
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (startConversation != null)
        {
            StartDialogue(startConversation);
        }

    }

    public void ChangeBackground(Image image)
    {
        background.sprite = image.sprite;
    }


    public string getCurrentSpeaker()
    {
        return currDialogue.character.name;
    }


    public void hideButton(Button button)
    {
        button.gameObject.SetActive(false);
    }

    public void showButton(Button button)
    {
        button.gameObject.SetActive(true);
    }

    public void StartDialogueWithID(string dialougeID)
    {
        foreach (DialogueHead head in conversationHeads)
        {
            if (head.conversationID.Equals(dialougeID))
            {
                StartDialogueFromHead(head);
            }
        }
    }

    public void StartDialogueFromHead(DialogueHead head)
    {
        if (head.background != null)
        {
            background.sprite = head.background;
        }
        StartDialogue(head.firstDialogue);


    }
    public void StartDialogue(Dialogue dialogue)
    {
        gameManager.PauseGame();
        //  Debug.Log("Starting conversation with " + dialogue.NPCName);

        currDialogue = dialogue;
        if (dialogue.character.NPCSprite != null)
        {
            characterSprite.sprite = dialogue.character.NPCSprite;
            characterSprite.gameObject.SetActive(true);
        }
        else if (dialogue.character.NPCSprite == null && !dialogue.character.name.Equals("You"))
        {
            characterSprite.gameObject.SetActive(false);
        }


        if (dialogue.character.voice != null)
        {
            characterVoice.clip = dialogue.character.voice;
            characterVoice.Play();
        }

        if (dialogue.background != null)
        {
            background.sprite = dialogue.background;
        }

        dialoguePanel.SetActive(true);
        continueButton.gameObject.SetActive(true);

        if (sentences != null)
        {
            sentences.Clear();
        } else
        {
            sentences = new Queue<string>();
        }
        


        nameText.text = currDialogue.character.NPCName;


        foreach (string sentence in currDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("click");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        if (currDialogue.dialogueTail != null)
        {
            if (currDialogue.dialogueTail.nextScene != "")
            {
                SceneManager.LoadScene(currDialogue.dialogueTail.nextScene);
            }
            if (currDialogue.dialogueTail.background != null)
            {
                background.sprite = currDialogue.dialogueTail.background;
            }

        }
        if (currDialogue.nextDialogue == null)
        {
            gameManager.UnpauseGame();
            dialoguePanel.SetActive(false);
            //   characterSprite.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
            if (loadNextScene != null)
            {
                loadNextScene.gameObject.SetActive(true);
            }


        }
        else
        {
            StartDialogue(currDialogue.nextDialogue);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }
}
