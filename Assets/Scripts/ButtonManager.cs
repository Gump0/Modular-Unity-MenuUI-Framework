using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonFunctions))]
public class ButtonManager : MonoBehaviour
{
    public ButtonFunctions buttonFunctions;

    public Image buttonHighlight;
    private UIInputManager inputManager;
    [SerializeField] private Image[] listOfButtons;
    private int buttonIndex = 0;
    public string[] methods;

    private Vector3 currentButtonLocation, highlightLocation; //Transform Lerp Animation stuff
    private Vector2 selectedWH, highlightWH; //Store image components height & width
    
    private float elapsedTime;
    
    private void Awake(){
        buttonHighlight = FindObjectOfType<Image>();

        inputManager = GetComponent<UIInputManager>();
        buttonFunctions = GetComponent<ButtonFunctions>();
        
        highlightLocation = buttonHighlight.transform.position;
        currentButtonLocation = new Vector3(listOfButtons[buttonIndex].transform.position.x, listOfButtons[buttonIndex].transform.position.y, buttonHighlight.transform.position.z);

        highlightWH = buttonHighlight.rectTransform.sizeDelta;
        selectedWH = new Vector2(listOfButtons[buttonIndex].rectTransform.sizeDelta.x, listOfButtons[buttonIndex].rectTransform.sizeDelta.y) + (Vector2.one*10);
    }

    void Update(){
        if (elapsedTime < 1){
            float t = Mathf.Sin(elapsedTime * Mathf.PI/2); // Updated to Sin(t * PI/2)
            buttonHighlight.transform.position = Vector3.Lerp(highlightLocation, currentButtonLocation, t); // transform lerp
            buttonHighlight.rectTransform.sizeDelta = Vector2.Lerp(highlightWH, selectedWH, t); // scale lerp
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
        highlightLocation = buttonHighlight.transform.position;
        buttonHighlight.transform.SetParent(listOfButtons[buttonIndex].transform);
        currentButtonLocation = listOfButtons[buttonIndex].transform.position;

        highlightWH = selectedWH; // stores value of prevoius button and sets it as highlight before transitioning to next button
        selectedWH = new Vector2(listOfButtons[buttonIndex].rectTransform.sizeDelta.x, listOfButtons[buttonIndex].rectTransform.sizeDelta.y) + (Vector2.one*10);

        elapsedTime = 0f;
    }
}