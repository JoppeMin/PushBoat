using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;


public class SceneManager : MonoBehaviour
{
    public static SceneManager SP;
    
    public Image TransitionImage;

#if UNITY_ANDROID
    string GameID = "3723799";
#endif


    [HideInInspector]
    public string socialMessage;

    void Awake()
    {
        Advertisement.Initialize(GameID, true);
        
        SP = this;
        TransitionImage.DOFade(0, .5f);
    }

    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (scene.name == "Menu" || scene.name == "Leaderboard")
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("banner");
        }
        else
        {
            Advertisement.Banner.Hide();
        }
    }

    void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        //UPDATE WITH GOOGLE PLAY LINK AND HASHTAGS
        socialMessage = "I just got a score of " + PlayerPrefs.GetInt("HighScore") + " in Push Boat, Try to beat my score! ";
    }

    public void Button_RateUs()
    {

        Application.OpenURL("http://play.google.com/store/apps/details?id=com.SidejopGames.PushBoat");
    }

    public void Button_Twitter()
    {
        Application.OpenURL("http://www.twitter.com/intent/tweet" + "?text=" + WWW.EscapeURL(socialMessage) + WWW.EscapeURL("http://play.google.com/store/apps/details?id=com.SidejopGames.PushBoat") + WWW.EscapeURL(" #Mobile #Android #PushBoat"));
    }

    public void Button_Facebook()
    {
        //add appid and such TEST TEST TEST
        //Application.OpenURL("http://www.facebook.com/sharer/sharer.php?u=" + WWW.EscapeURL(socialMessage));

       Application.OpenURL("http://www.facebook.com/dialog/share" + "?app_id=" + "213845043267767" + "&href=" + WWW.EscapeURL("http://play.google.com/store/apps/details?id=com.SidejopGames.PushBoat") +"&quote=" + socialMessage + WWW.EscapeURL(" #Mobile #Android #PushBoat") + "&display=popup" +"&redirect_uri=" + WWW.EscapeURL("http://www.facebook.com/"));
    }

    public void PlayButtonSound()
    {
        AudioManager.SP.Play("ButtonFeedback");
    }

    public void OpenLeaderboardGPG()
    {
        Social.ShowLeaderboardUI();
    }

    public void OpenScene(int sceneIndex)
    {
        if (sceneIndex == 2)
        {
                if (GPGAuthenticator.instance.isSignedIn)
                {
                    StartCoroutine(OpenSceneEnumerator(2));
                }
                else
                {
                    StartCoroutine(OpenSceneEnumerator(3));
                }
        }
        else
        {
            StartCoroutine(OpenSceneEnumerator(sceneIndex));
        }
        
    }
    
    IEnumerator OpenSceneEnumerator(int sceneIndex)
    {
        Tween tween = TransitionImage.DOFade(1, .5f);
        yield return tween.WaitForCompletion();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
