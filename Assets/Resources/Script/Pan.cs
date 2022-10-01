using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public GameObject oil;
    public bool burnOff = false;
    // if pan has ingredients -> cook recipies in 3 seconds
    // if pan only has oil    -> set on fire in 3 seconds
    // if pan was null        -> burn off the pan in 10 sec, game over
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oil != null)
        {
            
        }
    }

    public void Setoil(GameObject gameObject){
        oil = gameObject;
    }

    void BurnOff(){
        burnOff = true;
    }
}
