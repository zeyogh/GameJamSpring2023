using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("SHit");
             SceneManager.LoadScene("Intro");
        }
        
        
    }
}
