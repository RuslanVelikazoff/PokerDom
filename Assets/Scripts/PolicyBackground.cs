using UnityEngine;
using UnityEngine.UI;

public class PolicyBackground : MonoBehaviour
{
    [SerializeField] private Button acceptButton;

    [SerializeField] private PrivacyPolicyManager policyManager;

    private void OnEnable()
    {
        if (acceptButton != null)
        {
            acceptButton.onClick.RemoveAllListeners();
            acceptButton.onClick.AddListener(() =>
            {
                policyManager.ConfirmUserPolicy();
            });
        }
    }
}
