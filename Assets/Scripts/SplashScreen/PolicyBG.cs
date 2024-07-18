using UnityEngine;
using UnityEngine.UI;

public class PolicyBG : MonoBehaviour
{
    [SerializeField]
    private Button acceptButton;

    [SerializeField] 
    private BrowserPolicyManager policyManager;

    private void OnEnable()
    {
        if (acceptButton != null)
        {
            acceptButton.onClick.RemoveAllListeners();
            acceptButton.onClick.AddListener(() =>
            {
                policyManager.AcceptPolicy();
            });
        }
    }
}
