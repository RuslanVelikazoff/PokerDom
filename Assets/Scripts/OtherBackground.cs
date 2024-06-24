using UnityEngine;
using UnityEngine.UI;

public class OtherBackground : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button forwardButton;

    [SerializeField] 
    private PrivacyPolicyManager policyManager;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                policyManager.OnBackButtonPressed();
            });
        }

        if (forwardButton != null)
        {
            forwardButton.onClick.RemoveAllListeners();
            forwardButton.onClick.AddListener(() =>
            {
                policyManager.OnForwardButtonPressed();
            });
        }
    }
}
