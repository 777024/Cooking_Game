using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    public GameObject recipe;
    public float randomValue;
    // Update is called once per frame
    void Update()
    {
        randomValue = Random.value;
    }

    public void SetRecipe(){
        if (!recipe)
        {
            //Debug.Log("setRecipe");
            recipe = GetRandomRecipe(randomValue);
            recipe.transform.position = new Vector3(-8.98999977f,3.58999991f,0);
        } 
    }
    public bool isPlateFull(){
        if (recipe)
        return true;
        else
        return false;
    }
    public void Serve(){
        ResourcesPool.GetInstance().RecycleObj(recipe);
        recipe = null;
    }
    GameObject GetRandomRecipe(float x){
        switch ((int)(x * 10))
        {   case 0:
            case 1:
            return ResourcesPool.GetInstance().GetObj("Baguette");

            case 2:
            case 3:
            return ResourcesPool.GetInstance().GetObj("Burger");

            case 4:
            case 5:
            return ResourcesPool.GetInstance().GetObj("popcorn");

            case 6:
            case 7:
            return ResourcesPool.GetInstance().GetObj("Salmon");

            case 8:
            case 9:
            return ResourcesPool.GetInstance().GetObj("Steak");
            
            default:
            return ResourcesPool.GetInstance().GetObj("apple_pie");
        }
    }
}
