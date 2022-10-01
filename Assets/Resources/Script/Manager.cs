using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // manage mouse click on
    // manage response after mouse click
    GameObject sink;
    GameObject cutBoard;
    GameObject pan;
    GameObject seasonings;
    GameObject Oil;
    GameObject plate;
    GameObject ingredients;
    Camera cameraM;
    RaycastHit2D hit;
    Pan panScript;

    private void Awake() {
        sink = GameObject.Find("Sink");
        cutBoard = GameObject.Find("CutBoard");
        pan = GameObject.Find("Pan");
        seasonings = GameObject.Find("Seasonings");
        Oil = GameObject.Find("Oil");
        plate = GameObject.Find("plate");
        ingredients = GameObject.Find("Ingredients");
        cameraM = Camera.main;
        
    }

    private void Start() {
        panScript = pan.GetComponent<Pan>();
    }

    private void Update() {
        hit = Physics2D.Raycast(cameraM.ScreenToWorldPoint(MousePos()), Vector2.zero);
        if (hit.collider != null)
        {
            // Debug.Log(hit.collider.gameObject);
            AddOil(hit.collider.gameObject);
        }
    }

    Vector3 MousePos() {
        if (Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }
        return Vector3.zero;
    }

    void AddOil(GameObject gameObject){
        if (gameObject.name == "Oil")
        {
            panScript.Setoil(gameObject);
        }
    }

    void isGameOver(){
        if (panScript.burnOff)
        {
            Debug.Log("GAME OVER");
        }
    }
}
