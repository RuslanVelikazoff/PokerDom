using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] 
    private Button oddsCalculatorButton;
    [SerializeField] 
    private Button bankrollManagerButton;
    [SerializeField] 
    private Button combinationTrainerButton;
    [SerializeField] 
    private Button checklistButton;
    [SerializeField] 
    private Button newsAndStrategiesButton;
    [SerializeField] 
    private Button additionalButton;

    [Space(13)] 
    
    [SerializeField] 
    private GameObject oddsCalculatorPanel;
    [SerializeField] 
    private GameObject bankrollManagerPanel;
    [SerializeField] 
    private GameObject combinationTrainerPanel;
    [SerializeField] 
    private GameObject checklistPanel;
    [SerializeField]
    private GameObject newsAndStrategiesPanel;
    [SerializeField] 
    private GameObject additionalPanel;

    private void OnEnable()
    {
        ButtonClickAction();  
    }

    private void ButtonClickAction()
    {
        if (oddsCalculatorButton != null)
        {
            oddsCalculatorButton.onClick.RemoveAllListeners();
            oddsCalculatorButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                oddsCalculatorPanel.SetActive(true);
            });
        }

        if (bankrollManagerButton != null)
        {
            bankrollManagerButton.onClick.RemoveAllListeners();
            bankrollManagerButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                bankrollManagerPanel.SetActive(true);
            });
        }

        if (combinationTrainerButton != null)
        {
            combinationTrainerButton.onClick.RemoveAllListeners();
            combinationTrainerButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                combinationTrainerPanel.SetActive(true);
            });
        }

        if (checklistButton != null)
        {
            checklistButton.onClick.RemoveAllListeners();
            checklistButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                checklistPanel.SetActive(true);
            });
        }

        if (newsAndStrategiesButton != null)
        {
            newsAndStrategiesButton.onClick.RemoveAllListeners();
            newsAndStrategiesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                newsAndStrategiesPanel.SetActive(true);
            });
        }

        if (additionalButton != null)
        {
            additionalButton.onClick.RemoveAllListeners();
            additionalButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                additionalPanel.SetActive(true);
            });
        }
    }
}
