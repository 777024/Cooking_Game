using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public GameObject oil;
    public GameObject ingredients;
    public GameObject seasonings;
    public bool burnOff = false;
    public bool onFire = false; 
    public bool recipieDone = false;
    public int putOffCount = 10;
    Collider2D colliderPan;
 
    // if pan has ingredients -> recipies burn after 10s with your pan
    // if pan only has oil    -> set on fire in 3 seconds
    // if pan was null        -> burn off the pan in 10 sec, game over
    void Start()
    {
       colliderPan = gameObject.GetComponent<CircleCollider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (oil != null)
        {
            if (ingredients != null && seasonings != null)
            {
                StartCoroutine("RecipieBurn");
                colliderPan.enabled = true;
                if (recipieDone)
                {
                    StopCoroutine("RecipieBurn");
                    Debug.Log("recipie burn stop");
                    recipieDone = false;
                    CleanPan();
                }
            }
            else
            StartCoroutine("OilOnFire");
        }
        PutOutFire();
    }

    public void Setoil(GameObject gameObject){
        oil = gameObject;
    }

    public void SetIngredients(GameObject gameObject){
        ingredients = gameObject;
    }

    public void SetSeasoning(GameObject gameObject){
        seasonings = gameObject;
    }
    void CleanPan(){
        oil = null;
        ingredients = null;
        seasonings = null;
    }

    void PutOutFire(){
        if (onFire)
        {
            colliderPan.enabled = true;
            StartCoroutine("Timer");
            StopCoroutine("OilOnFire");
            if (putOffCount == 0)
            {
                StopCoroutine("Timer");
                onFire = false;
                Debug.Log("put off");
                putOffCount = 10;
                colliderPan.enabled = false;
                CleanPan();
            }
        }
        if (burnOff)
        {
            StopCoroutine("Timer");
        }
    }

    private void OnMouseDown() {
        if (ingredients != null){
            recipieDone = true;
        }else{
            putOffCount -= 1;
        }
    }
    void BurnOff(){
        burnOff = true;
        Debug.Log("Burn off");
    }

    private IEnumerator OilOnFire(){
        yield return new WaitForSeconds(4f);
        Debug.Log("onfire");
        onFire = true;
    }

    private IEnumerator Timer(){
        Debug.Log("Timer");
        yield return new WaitForSeconds(6f);
        BurnOff();
    }

    private IEnumerator RecipieBurn(){
        Debug.Log("RecipieBurn");
        yield return new WaitForSeconds(10f);
        BurnOff();
    }
    
}
