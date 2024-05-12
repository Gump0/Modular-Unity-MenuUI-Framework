using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private int transitionTime;
    private string nextSceneName;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            LoadNextScene("Under-Construction");
        }
    }

    public void LoadNextScene(string SceneName){
        nextSceneName = SceneName;
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene(){
        //Play Animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(nextSceneName);
    }
}