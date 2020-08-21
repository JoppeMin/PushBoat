using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiScript : MonoBehaviour
{
    public static int oldScore;
    public int Score;
    public int HighScore;
    public int Mistakes;
    public Sprite EmptyMistake;
    public Sprite MistakeImage;
    bool endUIShown = false;
    public GameObject EndUI;

    TextMeshPro ScoreText;
    public List<Image> MistakeUI;

    private void Start()
    {
        Mistakes = 0;
        Score = 0;
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        ScoreText.text = "" + Score;
        HighScore = PlayerPrefs.GetInt("HighScore");
        oldScore = HighScore;
        EndUI.SetActive(false);

        //FetchMistakeUi();

        EmptyMistake = MistakeUI[1].sprite;
    }

    public void AddPoints ()
    {
        Score++;
        AudioManager.SP.Play("PointSound");
        if (Score > HighScore)
        {
            ScoreText.outlineWidth = 0.1f;
            HighScore++;
        }
        ScoreText.text = "" + Score;
    }

    public void GameOverCheck()
    {
        if (Mistakes >= MistakeUI.Count)
        {
            if (!endUIShown)
            {
                PlayerPrefs.SetInt("HighScore", HighScore);

                BoatScript[] allBoats = FindObjectsOfType<BoatScript>();
                foreach (BoatScript boat in allBoats)
                {
                    boat.DestroyBoat();
                }
                FindObjectOfType<BoatSpawn>().paused = true;

                EndUI.SetActive(true);
            }
            else
            {
                GoToLeaderboardScene();
            }
             
        }
    }

    public void AddMistake()
    {
        MistakeUI[Mistakes].sprite = MistakeImage;
        MistakeUI[Mistakes].transform.DOPunchScale(new Vector3(1.2f, 1.5f), 0.2f, 1);
        Mistakes++;
        Handheld.Vibrate();
        AudioManager.SP.Play("MistakeSound");
        GameOverCheck();
    }

    public void RemoveMistake()
    {
        Mistakes--;
 
        if (MistakeUI[Mistakes] != null)
        {
            MistakeUI[Mistakes].sprite = EmptyMistake;
            MistakeUI[Mistakes].transform.DOPunchScale(new Vector3(1.2f, 1.5f), 0.2f, 1);
        }
    }

    public void ContinuePlayingAdReward()
    {
        RemoveMistake();
        endUIShown = true;
        FindObjectOfType<BoatSpawn>().paused = false;
        if (EndUI != null)
        {
            EndUI.SetActive(false);
        }
    }

    public void GoToLeaderboardScene()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        UpdateGPGLeaderboard();
        SceneManager.SP.OpenScene(2);
    }

    public void UpdateGPGLeaderboard()
    {
        Social.ReportScore(HighScore, GPGSIds.leaderboard_highscore, (bool success) => {

        });
    }

    public void FetchMistakeUi()
    {
        MistakeUI.Clear();
        GameObject[] MistakeUIGO = GameObject.FindGameObjectsWithTag("MistakeUI");
        for (int i = 0; i < MistakeUIGO.Length; i++)
        {
            MistakeUI.Add(MistakeUIGO[i].GetComponent<Image>());
        }
    }

    public void ResetScore()
    {
        Score = 0;
        Mistakes = 0;
    }
}
