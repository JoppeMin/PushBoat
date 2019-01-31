using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public int Score;
    public int HighScore;
    public int Mistakes;
    public Sprite MistakeImage;

    TextMeshPro ScoreText;
    GameObject[] MistakeUI;

    void Start()
    {
        Mistakes = 0;
        Score = 0;
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        HighScore = PlayerPrefs.GetInt("HighScore");
        MistakeUI = GameObject.FindGameObjectsWithTag("MistakeUI");
    }

    void Update()
    {
        ScoreText.text = "" + Score;
    }

    public void AddPoints ()
    {
        Score++;
        if (Score > HighScore)
        {
            HighScore++;
        }
    }

    public void GameOverCheck()
    {
        if (Mistakes >= MistakeUI.Length)
        {
            // Game Over Screen
        }
    }

    public void AddMistake()
    {
        MistakeUI[Mistakes].GetComponent<Animation>().Play();
        MistakeUI[Mistakes].GetComponent<Image>().sprite = MistakeImage;
        Mistakes++;
    }
}
