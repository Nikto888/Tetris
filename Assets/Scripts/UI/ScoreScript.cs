using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameLogic LogicController;
    public Text MyText;
    int Score = 0;

    void Start()
    {
        MyText.text = "Score: " + LogicController.GetScore().ToString();
    }

    void Update()
    {
        if (Score != LogicController.GetScore())
        {
            Score = LogicController.GetScore();
            MyText.text = "Score: " + Score.ToString();
        }
    }

}
