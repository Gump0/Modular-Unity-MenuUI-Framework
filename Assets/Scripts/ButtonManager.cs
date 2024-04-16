using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonFunctions))]
public class ButtonManager : MonoBehaviour
{
    public ButtonFunctions buttonFunctions;

    private GameObject buttonHighlight;
    private UIInputManager inputManager;
    [SerializeField] private Image[] listOfButtons;
    private int buttonIndex = 0;
    public string[] methods;

    //Transform Lerp Animation stuff
    private Transform currentButtonLocation, highlightLocation;
    private float elapsedTime;
    
    private void Awake(){
        inputManager = GetComponent<UIInputManager>();
        buttonFunctions = GetComponent<ButtonFunctions>();
        if (buttonHighlight == null) buttonHighlight = GameObject.Find("Highlight");
        
        highlightLocation = buttonHighlight.transform;
        currentButtonLocation = listOfButtons[buttonIndex].transform;
    }

    void Update(){
        if (elapsedTime < 2){
            float t = elapsedTime/2;
            buttonHighlight.transform.position = Vector3.Lerp(highlightLocation.position, currentButtonLocation.position, t);
            elapsedTime += Time.deltaTime;
        }
        CheckInputs();
    }
    void CheckInputs(){
        if (Input.GetKeyDown(inputManager.buttonKeys[3])){ // Right Input
            buttonFunctions.CallMethod(methods[3]);
            if(buttonIndex != listOfButtons.Length - 1) buttonIndex++;
            UpdateButtonHighlight();
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[1])){ // Left Input
            buttonFunctions.CallMethod(methods[1]);
            if(buttonIndex != 0) buttonIndex--;
            UpdateButtonHighlight();
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[0])){ // Up Input
            buttonFunctions.CallMethod(methods[0]);
            if(buttonIndex >= 2) buttonIndex -=2;
            UpdateButtonHighlight();
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[2])){ // Down Input
            buttonFunctions.CallMethod(methods[2]); 
            if(buttonIndex < listOfButtons.Length -2) buttonIndex +=2;
            UpdateButtonHighlight();
        }
    }

    void UpdateButtonHighlight(){
        highlightLocation = buttonHighlight.transform;
        buttonHighlight.transform.SetParent(listOfButtons[buttonIndex].transform);
        currentButtonLocation = listOfButtons[buttonIndex].transform;
        elapsedTime = 0f;
    }
}