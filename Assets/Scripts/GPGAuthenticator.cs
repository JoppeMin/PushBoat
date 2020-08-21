using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGAuthenticator : MonoBehaviour
{
    public static GPGAuthenticator instance;
    public static PlayGamesPlatform platform;
    public bool isSignedIn = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {


        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }
        
        Social.Active.localUser.Authenticate(succes =>
            {
                if (succes)
                {
                    isSignedIn = true;
                }
                else
                {
                    isSignedIn = false;
                }
            }
            );
    }
}
