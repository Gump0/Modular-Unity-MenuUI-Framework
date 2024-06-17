using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSheenLogic : MonoBehaviour
{
    private GameObject highlightObject;

    void Start(){
        if(highlightObject = null){
            highlightObject = GameObject.Find("Highlight");
        }
    }
    public void AdjustSheenSpriteLocation(){
        if(highlightObject != null){
            RectTransform highlightRT = highlightObject.GetComponent<RectTransform>();
            RectTransform sheenRT = GetComponent<RectTransform>(); // Apparently you need to reference rect transform for the object the monobehavior is attached too for some reason lmao

            sheenRT.sizeDelta = highlightRT.sizeDelta;

            transform.position = highlightObject.transform.position;
        }
    }
}
