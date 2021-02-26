using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TextureDataStruct
{
    public TextureDataStruct(Texture2D tex, string key)
    {
        this.tex = tex;
        this.key = key;
    }

    public Texture2D tex;
    public string key;
}

public class TextureHolder : MonoBehaviour
{
    private static TextureHolder instance;
    public static TextureHolder Instance
    {
        get
        {
            return instance;
        }
    }

    public List<TextureDataStruct> textures;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("QUIT!");
    }
}
