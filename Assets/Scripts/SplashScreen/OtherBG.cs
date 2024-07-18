using UnityEngine;
using UnityEngine.UI;

public class OtherBG : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button forwardButton;

    [SerializeField] 
    private UniWebView browser;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                if (browser.CanGoBack)
                {
                    browser.GoBack();
                }
            });
        }

        if (forwardButton != null)
        {
            forwardButton.onClick.RemoveAllListeners();
            forwardButton.onClick.AddListener(() =>
            {
                if (browser.CanGoForward)
                {
                    browser.GoForward();
                }
            });
        }
    }
}
