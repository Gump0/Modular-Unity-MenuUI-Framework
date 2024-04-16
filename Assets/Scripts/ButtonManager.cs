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
    public int buttonIndex = 0; //switch to private after

    public string[] methods;
    private void Awake()
    {
        inputManager = GetComponent<UIInputManager>();  
        buttonFunctions = GetComponent<ButtonFunctions>();
        if (buttonHighlight == null) buttonHighlight = GameObject.Find("Highlight");
    }

    void Update()
    {
        if (Input.GetKeyDown(inputManager.buttonKeys[0])){ // Left Input
            buttonFunctions.CallMethod(methods[0]);
            if(buttonIndex >= listOfButtons.Length +1) buttonIndex -=2;
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[1])){ // Right Input
            buttonFunctions.CallMethod(methods[1]);
            if(buttonIndex <= listOfButtons.Length -1) buttonIndex +=2;
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[2])){ // Up Input
            buttonFunctions.CallMethod(methods[2]);
            if(buttonIndex != listOfButtons.Length) buttonIndex++;
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[3])){ // Down Input
            buttonFunctions.CallMethod(methods[3]); 
            if(buttonIndex != 0) buttonIndex--;
        }
    }
}