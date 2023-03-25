using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DialoguePanel;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            PauseGame();
            DialoguePanel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UnpauseGame();
            DialoguePanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("fire");
            player.Fire();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
