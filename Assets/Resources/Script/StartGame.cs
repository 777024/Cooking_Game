using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI TextUI;
    int nextCount = 0;
    GameObject nextButton;
    GameObject startButton;
    private void Start() {
        nextButton = GameObject.Find("NextButton");
        startButton = GameObject.Find("StartButton");
        startButton.SetActive(false);
    }
    public void ChangeScene(){
        SceneManager.LoadScene("Scene1");
    }

    public void NextExplain(){
        
        if (nextCount == 0)
        {
            TextUI.text = "Luckly, if you stop using the stove, you can turn it off.";
            nextCount++;
        }
        else if(nextCount == 1){
            TextUI.text = "After ignite the stove, you need: \n 1, click the brown box on the right to put ingredients on cutting board.\n 2, click the oil bottle on the right top of the pan to add some oil";
            nextCount++; 
        }
        else if(nextCount == 2){
            TextUI.text = " 3, click spices above cutting board to seasoning\n 4, click the cutting board to add ingredient into pan\n 5, after step four, click the pan to put food on dish\n 6, click your dish to serve it";
            nextCount++; 
        }
        else if(nextCount == 3){
            TextUI.text = "It's easy, right?";
            nextCount++; 
        }else if(nextCount == 4){
            TextUI.text = "But, you have to notice the following!!!!\n 1, add oil, spices, ingredient in order\n 2, if the pan is empty on stove, after 10 sec, the kitchen to ashes\n 3, if pan is on fire, click the pan 10 times to put out fire ";
            nextCount++; 
        }else if(nextCount == 5){
            TextUI.text = "I think you are ready now";
            nextCount = 0; 
            nextButton.SetActive(false);
            startButton.SetActive(true);
        }
    }

    public void StoveIgnite(){
        
    }
}
