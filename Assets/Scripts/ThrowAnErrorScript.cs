using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAnErrorScript : MonoBehaviour
{
    public void ThrowDebugError(string errorDetails)
    {
        Debug.LogError(errorDetails);
    }
}
