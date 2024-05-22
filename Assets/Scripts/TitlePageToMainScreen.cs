using UnityEngine;
using UnityEngine.UI;

public class TitlePageToMainScreen : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader; // Scene Loader Reference

    void Update(){
        if(Input.anyKeyDown){
            TitlePageTransition();
        }
    }

    void TitlePageTransition(){
        sceneLoader.LoadNextScene("Main-Menu");
    }
}
