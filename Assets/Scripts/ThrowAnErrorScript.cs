using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAnErrorScript : MonoBehaviour
{
    public void ThrowDebugError(string errorDetails)
    {
        Debug.LogError(errorDetails);
    }

    public void ThrowOrdinaryDebug(string debugDetails)
    {
        Debug.Log(debugDetails);
    }

    public void DebugPosition(Vector2 pos)
    {
        Debug.Log(pos);
    }
}
