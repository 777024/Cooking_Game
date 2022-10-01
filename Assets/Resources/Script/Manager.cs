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
    Ingredients ingredientsScript;
    public GameObject ingredientOnBoard;

    private void Awake()
    {
        sink = GameObject.Find("Sink");
        cutBoard = GameObject.Find("CutBoard");
        pan = GameObject.Find("Pan");
        seasonings = GameObject.Find("Seasonings");
        Oil = GameObject.Find("Oil");
        plate = GameObject.Find("plate");
        ingredients = GameObject.Find("Ingredients");
        cameraM = Camera.main;

    }

    private void Start()
    {
        panScript = pan.GetComponent<Pan>();
        ingredientsScript = ingredients.GetComponent<Ingredients>();
    }

    private void Update()
    {
        hit = Physics2D.Raycast(cameraM.ScreenToWorldPoint(MousePos()), Vector2.zero);
        if (hit.collider != null)
        {
            // Debug.Log(hit.collider.gameObject);
            AddIngredients(hit.collider.gameObject);
            DragIngredient();
            if (hit.collider.gameObject.name == "CutBoard" && ingredientOnBoard != null && panScript.ingredients == null)
            {
                panScript.SetIngredients(ingredientOnBoard);
                ingredientOnBoard = null;
            }
        }
        isGameOver();
    }

    void DragIngredient()
    {

        if (hit.collider.gameObject.name == "Ingredients")
        {
            if (ingredientOnBoard == null)
            {
                if (Random.value < 0.3f)
                {
                    ingredientOnBoard = ResourcesPool.GetInstance().GetObj("Potato");
                }
                else if (Random.value < 0.6f)
                {
                    ingredientOnBoard = ResourcesPool.GetInstance().GetObj("Broccoli");
                }
                else if (Random.value < 1f)
                {
                    ingredientOnBoard = ResourcesPool.GetInstance().GetObj("Tomato");
                }
                ingredientOnBoard.transform.position = new Vector3(-5.07f,1.88f,0);
            }
        }
    }

    Vector3 MousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }
        return Vector3.zero;
    }

    void AddIngredients(GameObject gameObject)
    {
        if (gameObject.name == "Oil")
        {
            panScript.Setoil(gameObject);
        }
        if (gameObject.name == "Seasonings")
        {
            panScript.SetSeasoning(gameObject);
        }
    }

    void isGameOver()
    {
        if (panScript.burnOff)
        {
            Debug.Log("GAME OVER");
        }
    }
}
