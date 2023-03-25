using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationManager : MonoBehaviour
{
    [SerializeField]GameObject SS1;
    [SerializeField]GameObject SS2;
    [SerializeField]GameObject SS3;
    [SerializeField]GameObject beamPrefab;
    GameObject[] SpSt = new GameObject[3];
    int index = 0;
    float x, y, x2, y2;
    
    GameObject SpawnedBeam;
    int beamSpawned0 = 0;
    int beamSpawned1 = 0;

    
    

    void Awake(){
       
        Debug.Log(SS1.GetComponent<SpaceStationScript>().OnOrOff);
        Debug.Log(SS2.GetComponent<SpaceStationScript>().OnOrOff);
        Debug.Log(SS2.GetComponent<SpaceStationScript>().OnOrOff);
        

    }

    void Update(){

        if(SS1.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS1.GetComponent<SpaceStationScript>().arrAdded == 0){
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

        
        if(index==2 && beamSpawned0 == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned0 = 1;
            x = SpSt[0].transform.position.x;
            x2 = SpSt[1].transform.position.x;
            y = SpSt[0].transform.position.y;
            y2 = SpSt[1].transform.position.y;

            angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }

        if(index==3 && beamSpawned1 == 0){
            float angleRotaion;
            float diagDistance;

            beamSpawned1 = 1;
            x = SpSt[2].transform.position.x;
            x2 = SpSt[1].transform.position.x;
            y = SpSt[2].transform.position.y;
            y2 = SpSt[1].transform.position.y;

            angleRotaion = (float)System.Math.Atan((y-y2)/(x-x2))*(float).5;
            diagDistance = Mathf.Sqrt(((x-x2)*(x-x2)) + ((y-y2)*(y-y2)));

            SpawnedBeam = Instantiate(beamPrefab, new Vector3(((x+x2)/2), ((y+y2)/2), 0), new Quaternion(0,0,angleRotaion,1));

            SpawnedBeam.transform.localScale = new Vector3(diagDistance/12,1,1);

            Debug.Log("Beam Should Spawn and be visible");
            
        }

        
    }

    


}
