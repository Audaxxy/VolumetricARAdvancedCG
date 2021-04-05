using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public string sceneName;
    public GameObject playerRig;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MenuButton")
        {
            Destroy(playerRig);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        
    }
}
