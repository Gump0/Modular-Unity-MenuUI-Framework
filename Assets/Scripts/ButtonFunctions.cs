using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader; // Scene Loader Reference
    [SerializeField] private ModelSwap ms; // Model swapper reference (only use for character select scene)

    public void CallMethod(string methodName){
        Invoke(methodName, Time.deltaTime); //Call this without MONOBEHAVIOR
    }
    public void Play(){
        sceneLoader.LoadNextScene("Under-Construction");
    }
    public void Settings(){
        sceneLoader.LoadNextScene("Under-Construction");
    }
    public void HowToPlay(){
        sceneLoader.LoadNextScene("Under-Construction");
    }
    public void BackArrow(){
        if(ms.modelIndex <= 0){
            ms.modelIndex = ms.listOfModels.Length;
        }else{
            ms.modelIndex--;
        }
    }
    public void ForwardArrow(){
        if(ms.modelIndex >= ms.listOfModels.Length){
            ms.modelIndex = 0;
        }else{
            ms.modelIndex++;
        }
    }
}
