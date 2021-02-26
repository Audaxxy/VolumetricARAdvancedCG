using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    private static Dictionary<string, string> sceneDict = new Dictionary<string, string>();

    public bool registerSceneOnAwake = false;
    public string mySceneKey;
    public string myScene;
    private string trimmedName;

    private void Awake()
    {
        SetSceneInDictionary();
    }

    public void SetSceneInDictionary()
    {
        if (myScene == "")
            return;

        trimmedName = TrimSceneName(myScene);

        if (registerSceneOnAwake)
        {
            LoadSceneIntoDictionary(mySceneKey);
        }
    }

    public static void LoadSceneFromDictionary(string key)
    {
        if (key == "")
        {
            Debug.Log("EMPTY SCENE KEY!");
            return;
        }

        SceneManager.LoadScene(sceneDict[key]);
    }

    public void LoadMyScene()
    {
        if (trimmedName == "")
        {
            Debug.Log("EMPTY SCENE NAME!");
            return;
        }

        SceneManager.LoadSceneAsync(trimmedName);
    }

    public void LoadSceneIntoDictionary(string key)
    {
        Debug.Log("LOADED: " + key);

        if (sceneDict.ContainsKey(key))
        {
            sceneDict[key] = trimmedName;
        }
        else
        {
            sceneDict.Add(key, trimmedName);
        }
    }


    //Scenes return full asset path when using the above code
    //This trims it down to just the scene name
    string TrimSceneName(string sceneName)
    {
        string[] directories = sceneName.Split('/');
        return directories[directories.Length - 1].Split('.')[0];
    }
}
