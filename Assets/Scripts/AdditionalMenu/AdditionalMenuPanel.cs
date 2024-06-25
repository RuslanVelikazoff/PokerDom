using UnityEngine;
using UnityEngine.UI;

public class AdditionalMenuPanel : MonoBehaviour
{
    [SerializeField] 
    private Button glossaryButton;
    [SerializeField] 
    private Button timerButton;
    [SerializeField]
    private Button notesButton;
    [SerializeField]
    private Button betSizeCalculatorButton;
    [SerializeField] 
    private Button passwordGeneratorButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject glossaryPanel;
    [SerializeField]
    private GameObject timerPanel;
    [SerializeField] 
    private GameObject notesPanel;
    [SerializeField] 
    private GameObject betSizeCalculatorPanel;
    [SerializeField] 
    private GameObject passwordGeneratorPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (glossaryButton != null)
        {
            glossaryButton.onClick.RemoveAllListeners();
            glossaryButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                glossaryPanel.SetActive(true);
            });
        }

        if (timerButton != null)
        {
            timerButton.onClick.RemoveAllListeners();
            timerButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                timerPanel.SetActive(true);
            });
        }

        if (notesButton != null)
        {
            notesButton.onClick.RemoveAllListeners();
            notesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                notesPanel.SetActive(true);
            });
        }

        if (betSizeCalculatorButton != null)
        {
            betSizeCalculatorButton.onClick.RemoveAllListeners();
            betSizeCalculatorButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                betSizeCalculatorPanel.SetActive(true);
            });
        }

        if (passwordGeneratorButton != null)
        {
            passwordGeneratorButton.onClick.RemoveAllListeners();
            passwordGeneratorButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                passwordGeneratorPanel.SetActive(true);
            });
        }
    }
}
