using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    public bool recipe;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRecipe(bool r){
        recipe = r;
    }
    public bool isPlateFull(){
        if (recipe)
        return true;
        else
        return false;
    }
}
