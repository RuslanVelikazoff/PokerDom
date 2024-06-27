using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankrollManagerPanel : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField betAmountInputField;
    [SerializeField] 
    private TMP_InputField notesInputField;

    [Space(13)]
    
    [SerializeField] 
    private Button winButton;
    [SerializeField] 
    private Button loseButton;
    [SerializeField] 
    private Sprite activeSprite;
    [SerializeField]
    private Sprite inactiveSprite;

    [Space(13)]
    
    [SerializeField] 
    private Button createBetButton;
    [SerializeField]
    private Button analyzeButton;
    [SerializeField] 
    private GameObject analyzePanel;

    [Space(13)]
    
    [SerializeField]
    private BetScrollView scrollView;

    private bool selectedStatus;

    private void OnEnable()
    {
        ClearAllInputFields();
        scrollView.ResetAllBets();
        scrollView.SpawnPrefabsInScrollView();
        
        selectedStatus = true;
        SetButtonSprite();
        
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (analyzeButton != null)
        {
            analyzeButton.onClick.RemoveAllListeners();
            analyzeButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                analyzePanel.SetActive(true);
            });
        }

        if (createBetButton != null)
        {
            createBetButton.onClick.RemoveAllListeners();
            createBetButton.onClick.AddListener(() =>
            {
                CreateNewBet();
                scrollView.ResetAllBets();
                scrollView.SpawnPrefabsInScrollView();
            });
        }

        if (winButton != null)
        {
            winButton.onClick.RemoveAllListeners();
            winButton.onClick.AddListener(() =>
            {
                selectedStatus = true;
                SetButtonSprite();
            });
        }

        if (loseButton != null)
        {
            loseButton.onClick.RemoveAllListeners();
            loseButton.onClick.AddListener(() =>
            {
                selectedStatus = false;
                SetButtonSprite();
            });
        }
    }

    private void CreateNewBet()
    {
        if (betAmountInputField.text != string.Empty)
        {
            BetData.Instance.AddBetAmount(float.Parse(betAmountInputField.text));
            BetData.Instance.AddBetNotes(notesInputField.text);
            BetData.Instance.AddBetStatus(selectedStatus);
            ClearAllInputFields();
        }

    }

    private void ClearAllInputFields()
    {
        betAmountInputField.text = string.Empty;
        notesInputField.text = string.Empty;

        selectedStatus = true;
        SetButtonSprite();
    }

    private void SetButtonSprite()
    {
        if (selectedStatus)
        {
            winButton.GetComponent<Image>().sprite = activeSprite;
            loseButton.GetComponent<Image>().sprite = inactiveSprite;
        }
        else
        {
            winButton.GetComponent<Image>().sprite = inactiveSprite;
            loseButton.GetComponent<Image>().sprite = activeSprite;
        }
    }
}
