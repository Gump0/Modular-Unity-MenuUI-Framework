using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructionScript : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader; // Scene Loader Reference
    private float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 3){
            sceneLoader.LoadNextScene("Main-Menu");
        }
    }
}
