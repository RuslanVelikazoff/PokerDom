using UnityEngine;
using UnityEngine.UI;

public class BackButtonAction : MonoBehaviour
{
    [SerializeField] 
    private GameObject closePanel;
    [SerializeField]
    private GameObject openPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button backButton;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                closePanel.SetActive(false);
                openPanel.SetActive(true);
            });
        }
    }
}
