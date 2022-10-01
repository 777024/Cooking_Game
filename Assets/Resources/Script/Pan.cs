using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public GameObject oil;
    public bool burnOff = false;
    public bool onFire = false; 
    public int putOffCount = 10;
    Collider2D colliderPan;
 
    // if pan has ingredients -> cook recipies in 3 seconds
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
            StartCoroutine("OilOnFire");
        }
        PutOutFire();
    }

    public void Setoil(GameObject gameObject){
        oil = gameObject;
    }

    void PutOutFire(){
        if (onFire == true)
        {
            colliderPan.enabled = true;
            StopCoroutine("OilOnFire");
            if (putOffCount == 0)
            {
                onFire = false;
                Debug.Log("put off");
                putOffCount = 10;
                colliderPan.enabled = false;
            }
        }
    }

    private void OnMouseDown() {
        putOffCount -= 1;
    }
    void BurnOff(){
        burnOff = true;
    }

    private IEnumerator OilOnFire(){
        yield return new WaitForSeconds(3f);
        Debug.Log("onfire");
        onFire = true;
    }

    private IEnumerator Timer(){
        yield return new WaitForSeconds(1f);
    }
}
