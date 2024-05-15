using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader; // Scene Loader Reference

    public void CallMethod(string methodName){
        Invoke(methodName, Time.deltaTime); //Call this without MONOBEHAVIOR
    }
    public void Play(){
        sceneLoader.LoadNextScene("Under-Construction");
    }
    public void Settings(){
        Debug.Log("Settings");
    }
    public void HowToPlay(){
        Debug.Log("HowToPlay");
    }
}
