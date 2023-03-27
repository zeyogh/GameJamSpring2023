using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStationManager : MonoBehaviour
{
    [SerializeField]GameObject SS1;
    [SerializeField]GameObject SS2;
    [SerializeField]GameObject SS3;
    [SerializeField]GameObject SS4;
    [SerializeField]GameObject SS5;
    [SerializeField]GameObject SS6;
    [SerializeField]GameObject SS7;
    [SerializeField]GameObject SS8;
    [SerializeField]GameObject SS9;
    [SerializeField]GameObject beamPrefab;
    [SerializeField] GameObject l1;
    [SerializeField] GameObject l2;
    [SerializeField] GameObject l3;
    [SerializeField] GameObject l4;
    [SerializeField] GameObject l5;
    [SerializeField] GameObject l6;
    [SerializeField] GameObject l7;
    [SerializeField] GameObject l8;
    [SerializeField] GameObject l9;
    GameObject[] SpSt = new GameObject[10];
    int index = 0;
    float x, y, x2, y2;
    public int allOn = 0;
    
    GameObject SpawnedBeam;
    int[] beamSpawned = new int[9];

    [SerializeField] Dialogue level1dio;
    public DialogueManager dialogueManager;
    private bool on = false;
    

    
    

    void Awake(){
       
        Debug.Log(SS1.GetComponent<SpaceStationScript>().OnOrOff);
        Debug.Log(SS2.GetComponent<SpaceStationScript>().OnOrOff);
        Debug.Log(SS2.GetComponent<SpaceStationScript>().OnOrOff);
        

    }

    void Update(){
        //Debug.Log(SceneManager.GetActiveScene().ToString());
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Level1")) && allOn == 1 && !on)
        {
            dialogueManager.StartDialogue(level1dio);
            on = true;
        }

        if (SS1.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS1.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS1;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS2.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS2.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS2;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS3.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS3.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS3;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS4.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS4.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS4;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS5.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS5.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS5;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS6.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS6.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS6;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS7.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS7.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS7;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS8.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS8.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS8;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }
        if(SS9.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS9.GetComponent<SpaceStationScript>().arrAdded == 0){
            SpSt[index] = SS9;
            SpSt[index].GetComponent<SpaceStationScript>().arrAdded = 1;
            index++;
        }

        if(index == 9){
            SpSt[0].GetComponent<SpaceStationScript>().arrAdded = 0;
            SpSt[0].GetComponent<SpaceStationScript>().OnOrOff = 0;
        }

        if(index == 10){
            allOn = 1;
            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Level2")))
            {
                l1.SetActive(true);
                l2.SetActive(true);
                l3.SetActive(true);
                l4.SetActive(true);
                l5.SetActive(true);
                l6.SetActive(true);
                l7.SetActive(true);
                l8.SetActive(true);
                l9.SetActive(true);

            }
        }
        
        
        if(index==2 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2] = 1;
            x = SpSt[index-2].transform.position.x;
            x2 = SpSt[index-1].transform.position.x;
            y = SpSt[index-2].transform.position.y;
            y2 = SpSt[index-1].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }

        if(index==3 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==4 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==5 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==6 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==7 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==8 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==9 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).625;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }
        if(index==10 && beamSpawned[index-2] == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned[index-2]= 1;
            x = SpSt[index-1].transform.position.x;
            x2 = SpSt[index-2].transform.position.x;
            y = SpSt[index-1].transform.position.y;
            y2 = SpSt[index-2].transform.position.y;

            if((x-x2)*(x-x2) > ((y-y2)*(y-y2))){    
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            }else
            {
                angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).62;
            }
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }

        
    }

    


}
