using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void CallMethod(string methodName)
    {
        Invoke(methodName, Time.deltaTime); //Call this without MONOBEHAVIOR
    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
