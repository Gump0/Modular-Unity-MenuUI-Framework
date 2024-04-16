using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void CallMethod(string methodName){
        Invoke(methodName, Time.deltaTime); //Call this without MONOBEHAVIOR
    }
    public void Test1(){
        Debug.Log("Left");
    }
    public void Test2(){
        Debug.Log("Right");
    }
    public void Test3(){
        Debug.Log("Up");
    }
    public void Test4(){
        Debug.Log("Down");
    }
}