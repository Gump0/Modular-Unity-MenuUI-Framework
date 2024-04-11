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
    private Image[] listOfButtons;

    public string[] methods;
    private void Awake()
    {
        inputManager = GetComponent<UIInputManager>();  
        buttonFunctions = GetComponent<ButtonFunctions>();
    }

    void Update()
    {
        if (Input.GetKeyDown(inputManager.buttonKeys[0])) buttonFunctions.CallMethod(methods[0]);
        if (Input.GetKeyDown(inputManager.buttonKeys[1])) buttonFunctions.CallMethod(methods[1]);
    }
}