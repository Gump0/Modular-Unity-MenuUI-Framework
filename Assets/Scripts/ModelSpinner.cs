using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpinner : MonoBehaviour
{
    public float spinIncrement, spinMultiplier;
    private Transform spinningModel;

    void Start(){
        spinningModel = transform.Find("Model");
    }
    void Update()
    {
        spinIncrement += Time.deltaTime * spinMultiplier;
        if(spinIncrement > 360){
            spinIncrement = 0f;
        }
        spinningModel.transform.rotation = Quaternion.Euler(transform.rotation.x, spinIncrement, transform.rotation.z);
    }
}
