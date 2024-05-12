using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadNextScene(string SceneName){
        SceneManager.LoadScene("SceneName");
    }

    IEnumerator LoadScene(int sceneIndex){
        //Play Animation

        //Wait
        
        //Load Scene
        return null;
    }
}
