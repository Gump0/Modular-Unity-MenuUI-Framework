using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSheenLogic : MonoBehaviour
{
    public GameObject sheenObject;
    private GameObject highlightObject;

    void Start(){
        if(sheenObject == null){
            sheenObject = GameObject.Find("ButtonSheen");
        }
        if(highlightObject = null){
            highlightObject = GameObject.Find("Highlight");
        }
    }
    public void AdjustSheenSpriteLocation(){
        //sheenObject.transform.position = 
    }
}
