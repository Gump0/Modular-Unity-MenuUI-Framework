using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwap : MonoBehaviour
{
    public GameObject[] listOfModels;
    private GameObject selectedModel, prevoiusModel, modelParent;
    public int modelIndex = 0;

    void Start()
    {
        modelParent = GameObject.Find("Model");
        selectedModel = listOfModels[modelIndex];
        //Instantiate first object w/out setting a prevoius model
        selectedModel = Instantiate(listOfModels[modelIndex], modelParent.transform.position, Quaternion.identity, transform);
        if(modelParent != null){
            selectedModel.transform.parent = modelParent.transform;
        }
    }

    public void UpdateModel(){
        prevoiusModel = selectedModel;
        if(selectedModel != null){
            Destroy(selectedModel);
        }
        selectedModel = Instantiate(listOfModels[modelIndex], modelParent.transform.position, Quaternion.identity, transform);
        if(modelParent != null){
            selectedModel.transform.parent = modelParent.transform;
        }
    }
}
