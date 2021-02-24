using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WebCamTest : MonoBehaviour
{
    private WebCamTexture wct;
    private Material myMaterial;

    private void Awake()
    {
        Debug.Log(Screen.height + ", " + Screen.width);

        myMaterial = GetComponent<Renderer>().material;
        wct = new WebCamTexture();

        myMaterial.mainTexture = wct;

        Vector3 localScale = transform.localScale;
        localScale.z = (float)Screen.height / (float)Screen.width;
        transform.localScale = localScale;
    }

    private void OnEnable()
    {
        wct.Play();
    }

    private void OnDisable()
    {
        wct.Stop();
    }

    private void OnDestroy()
    {
        Destroy(myMaterial);
        Destroy(wct);
    }
}
