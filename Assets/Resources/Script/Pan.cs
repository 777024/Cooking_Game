using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public GameObject oil;
    public GameObject fire;
    public GameObject ingredients;
    public GameObject seasonings;
    GameObject plate;
    public bool burnOff = false;
    public bool onFire = false; 
    public bool recipeDone = false;
    public int putOffCount = 10;
    Collider2D colliderPan;
    Plate plateScript;
    AudioSource audioSource;
 
    // if pan has ingredients -> recipes burn after 10s with your pan
    // if pan only has oil    -> set on fire in 3 seconds
    // if pan was null        -> burn off the pan in 10 sec, game over
    void Start()
    {
       colliderPan = gameObject.GetComponent<CircleCollider2D>();
       plate = GameObject.Find("Plate");
       plateScript = plate.GetComponent<Plate>();
       audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oil != null)
        {
            // audioSource.Play();
            StopCoroutine("PanBurn");
            if (ingredients != null && seasonings != null)
            {
                StopCoroutine("OilOnFire");
                StartCoroutine("RecipeBurn");
                colliderPan.enabled = true;
                if (recipeDone && !plateScript.isPlateFull())
                {
                    StopCoroutine("RecipeBurn");
                    plateScript.SetRecipe();
                    //Debug.Log("recipe burn stop");
                    recipeDone = false;
                    colliderPan.enabled = false;
                    CleanPan();
                }
            }
            else
            StartCoroutine("OilOnFire");
        }
        if (IsPanEmpty())
        {
            StartCoroutine("PanBurn");
        }
        PutOutFire();
    }

    public void Setoil(){
        if(IsPanEmpty())
        oil = ResourcesPool.GetInstance().GetObj("Oil");
    }

    public bool SetIngredients(GameObject gameObject){
        if(oil && seasonings){
            ingredients = gameObject;
            ingredients.transform.position = new Vector3(0.140000001f,2.52999997f,0);
            return true;
        }
        return false;
        
    }

    public void SetSeasoning(GameObject gameObject){
        if(oil && !ingredients)
        seasonings = ResourcesPool.GetInstance().GetObj("Spices");
    }
    void CleanPan(){
        if(oil){
            ResourcesPool.GetInstance().RecycleObj(oil);
            oil = null;
        }
        if(ingredients){
            ResourcesPool.GetInstance().RecycleObj(ingredients);
            ingredients = null;
        }
        if (seasonings)
        {
            ResourcesPool.GetInstance().RecycleObj(seasonings);
            seasonings = null;
        }
    }
    bool IsPanEmpty(){
        if(oil == null && ingredients == null && seasonings == null)
        return true;
        else
        return false;
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
                ResourcesPool.GetInstance().RecycleObj(fire);
                fire = null;
                //Debug.Log("put off");
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
            recipeDone = true;
        }else{
            putOffCount -= 1;
        }
    }
    void BurnOff(){
        burnOff = true;
        // Debug.Log("Burn off");
    }



    private IEnumerator OilOnFire(){
        yield return new WaitForSeconds(4f);
        //Debug.Log("onfire");
        fire = ResourcesPool.GetInstance().GetObj("Fire");
        fire.transform.position = new Vector3(0.140000001f,2.52999997f,0);
        onFire = true;
    }

    private IEnumerator Timer(){
        // Debug.Log("Timer");
        yield return new WaitForSeconds(6f);
        BurnOff();
    }

    private IEnumerator RecipeBurn(){
        // Debug.Log("RecipeBurn");
        yield return new WaitForSeconds(10f);
        BurnOff();
    }

    private IEnumerator PanBurn(){
        yield return new WaitForSeconds(10f);
        BurnOff();
    }
    
}
