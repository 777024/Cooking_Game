using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    GameObject recipe;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRecipe(GameObject gameObject){
        recipe = gameObject;
    }
}
