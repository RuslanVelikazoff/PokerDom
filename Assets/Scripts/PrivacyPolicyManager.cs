using System.Collections;
using UnityEngine;

public class PrivacyPolicyManager : MonoBehaviour
{
    [SerializeField]
    private LoadingPanel loadManager;
    [SerializeField]
    private UniWebView browser;
    [SerializeField]
    private string policyWebUrl;
    [SerializeField]
    private GameObject noInternetUI;
    [SerializeField]
    private GameObject loadingUI;
    [SerializeField]
    private GameObject policyBackground, fallbackBackground;

    private bool isPolicyLoaded = false;

    private void Awake()
    {
        SetScreenOrientation();
        CheckInternetAndProceed();
    }

    private void SetScreenOrientation()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void CheckInternetAndProceed()
    {
        if (IsNetworkUnavailable())
        {
            ShowNoInternetUI();
        }
        else
        {
            ExecutePolicyFlow();
        }
    }

    private bool IsNetworkUnavailable()
    {
        return Application.internetReachability == NetworkReachability.NotReachable;
    }

    private void ShowNoInternetUI()
    {
        loadingUI.SetActive(false);
        noInternetUI.SetActive(true);
    }

    private IEnumerator ReconnectAndProceed()
    {
        while (IsNetworkUnavailable())
        {
            ShowNoInternetUI();
            yield return new WaitForSeconds(5f);
        }

        InitiatePolicyWebLoad();
    }

    private void InitiatePolicyWebLoad()
    {
        noInternetUI.SetActive(false);
        loadingUI.SetActive(true);
        StartPolicyPageLoading();
    }

    private void StartPolicyPageLoading()
    {
        browser.OnPageFinished += OnPolicyPageLoaded;
        browser.Load(policyWebUrl);
    }

    private void OnPolicyPageLoaded(UniWebView browser, int status, string url)
    {
        if (isPolicyLoaded) return;

        UpdateUIOnPageLoad(url);
        browser.Show();

        if (policyWebUrl != url)
        {
            Destroy(this.gameObject);
        }

        isPolicyLoaded = true;
    }

    private void UpdateUIOnPageLoad(string url)
    {
        bool isPolicyPage = url == policyWebUrl;
        GameObject activeBg = isPolicyPage ? policyBackground : fallbackBackground;
        activeBg.SetActive(true);
        Screen.orientation = isPolicyPage ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyStatus", isPolicyPage ? "Accepted" : url);
    }

    public void ConfirmUserPolicy()
    {
        ExecutePolicyFlow();
    }

    private void ExecutePolicyFlow()
    {
        string status = PlayerPrefs.GetString("PolicyStatus", "");
        if (string.IsNullOrEmpty(status))
        {
            StartCoroutine(ReconnectAndProceed());
        }
        else if (status == "Accepted")
        {
            policyBackground.SetActive(false);
            browser.gameObject.SetActive(false);
            loadingUI.SetActive(true);
            loadManager.StartLoading();
        }
        else
        {
            LoadPreviousPolicyPage(status);
        }
    }

    private void LoadPreviousPolicyPage(string url)
    {
        browser.Load(url);
        browser.Show();
        fallbackBackground.SetActive(true);
    }

    public void OnBackButtonPressed()
    {
        if (browser.CanGoBack)
        {
            browser.GoBack();
        }
    }

    public void OnForwardButtonPressed()
    {
        if (browser.CanGoForward)
        {
            browser.GoForward();
        }
    }
}