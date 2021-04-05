using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public List<string> buttonNames;
    public string sceneName;
    public GameObject playerRig;

    //When Button Top hits TriggerPlate do something based on Button name.
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == buttonNames[0])
        {
            QuitButton();
        }
        else if(col.gameObject.name == buttonNames[1])
        {
            ButtonOne();
        }
    }
    void ButtonOne()
    {
        Destroy(playerRig);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void QuitButton(){
        Application.Quit();
    }
}
