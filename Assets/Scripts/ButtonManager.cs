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
    [SerializeField] private UIInputManager inputManager;
    [SerializeField] private Image[] listOfButtons;
    public int buttonIndex = 0;
    public string[] methods;

    private Vector3 currentButtonLocation; //Transform Lerp Animation stuff
    private Vector2 selectedWH, highlightWH; //Store image components height & width
    
    [SerializeField] private float elapsedTime;
    
    private void Awake(){
        buttonHighlight = GameObject.FindGameObjectWithTag("Highlight")?.GetComponent<Image>(); //Patch that fixes loading screen from becoming highlight image (whoopsie)

        inputManager = GetComponent<UIInputManager>();
        buttonFunctions = GetComponent<ButtonFunctions>();

        currentButtonLocation = new Vector3(listOfButtons[buttonIndex].transform.position.x, listOfButtons[buttonIndex].transform.position.y, buttonHighlight.transform.position.z);

        highlightWH = buttonHighlight.rectTransform.sizeDelta;
        selectedWH = new Vector2(listOfButtons[buttonIndex].rectTransform.sizeDelta.x, listOfButtons[buttonIndex].rectTransform.sizeDelta.y) + (Vector2.one*10);
    }

    void Update(){
        if (elapsedTime < 1){
            float t = Mathf.Sin(elapsedTime * Mathf.PI/2); // Updated to Sin(t * PI/2)
            buttonHighlight.transform.position = Vector3.Lerp(buttonHighlight.transform.position, currentButtonLocation, t); // transform lerp
            buttonHighlight.rectTransform.sizeDelta = Vector2.Lerp(highlightWH, selectedWH, t); // scale lerp
            elapsedTime += Time.deltaTime;
        }
        CheckInputs();
    }
    void CheckInputs(){
        if (Input.GetKeyDown(inputManager.buttonKeys[3])){ // Right Input
            //buttonFunctions.CallMethod(methods[3]);
            buttonIndex++;
            elapsedTime = 0f;
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[1])){ // Left Input
            buttonIndex--;
            elapsedTime = 0f;
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[0])){ // Up Input
            buttonIndex -=2;
            elapsedTime = 0f;
        }
        if (Input.GetKeyDown(inputManager.buttonKeys[2])){ // Down Input 
            buttonIndex +=2;
            elapsedTime = 0f;
        }
        buttonIndex += listOfButtons.Length;
        buttonIndex = buttonIndex % listOfButtons.Length;


        UpdateButtonHighlight(); // Fix this issue, its not working  :p


        if (Input.GetKeyDown(inputManager.buttonKeys[4])){ // Select/Fire Input
        //Reworked so that instead of using string array 'methods' we instead name the buttons after the functions, and exectute the regarding function accordingly
        //Making setting up several menu scenes far easier...
            GameObject selectedButton = listOfButtons[buttonIndex].gameObject;
            string selectedFunction = selectedButton.name;
            buttonFunctions.CallMethod(selectedFunction);

            //Debug.Log("Parent GameObject of " + selectedButton  .name + " is: " + selectedFunction);
        }
    }
    void UpdateButtonHighlight(){
        buttonHighlight.transform.SetParent(listOfButtons[buttonIndex].transform);
        currentButtonLocation = listOfButtons[buttonIndex].transform.position;

        highlightWH = selectedWH; // stores value of prevoius button and sets it as highlight before transitioning to next button
        selectedWH = new Vector2(listOfButtons[buttonIndex].rectTransform.sizeDelta.x, listOfButtons[buttonIndex].rectTransform.sizeDelta.y) + (Vector2.one*10);
    }
}