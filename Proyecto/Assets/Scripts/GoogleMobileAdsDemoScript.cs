using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    private float tiempo_inicio = 0.0F;
    private float tiempo_final = 7.0F;

    public void Start()
    {

#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        PlayerPrefs.SetInt("pu", 0);
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("pu") == 0)
        {
            string escena = SceneManager.GetActiveScene().name;
            if (escena.Equals("P_MenuPrin"))
            {
                RequestBanner();
                PlayerPrefs.SetInt("pu", 1);
            }
            if (!escena.Equals("P_MenuPrin"))
            {
                if (this.bannerView != null)
                {
                    this.bannerView.Destroy();
                }
                PlayerPrefs.SetInt("pu", 2);
            }
        }
        if(PlayerPrefs.GetInt("pu") == 1)
        {
            tiempo_inicio += Time.deltaTime;
            if (tiempo_inicio >= tiempo_final)
            {
                if (this.bannerView != null)
                {
                    this.bannerView.Destroy();
                }
                PlayerPrefs.SetInt("pu", 2);
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                PlayerPrefs.SetInt("pu", 0);
                PlayerPrefs.SetInt("lock", 0);
                DestroyBanner("P_Inicio");
            }
        }
    }

    public void DestroyBanner(string escena)
    {
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
        PlayerPrefs.SetInt("lock", 0);
        SceneManager.LoadScene(escena);
    }

    // Returns an ad request with custom ad targeting.
    public AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1985, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    public void RequestBanner()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
    }
   
    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    #endregion

}
