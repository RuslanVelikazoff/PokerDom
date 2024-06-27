using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombinationTrainerPanel : MonoBehaviour
{
    [SerializeField] 
    private Image combinationImage;
    [SerializeField] 
    private Sprite[] combinationSprite;

    [Space(13)]
    
    [SerializeField] 
    private Button[] answerButton;
    [SerializeField] 
    private Color selectedColor;
    [SerializeField] 
    private Color defaultColor;

    [Space(13)]
    
    [SerializeField] 
    private Button nextButton;
    [SerializeField] 
    private GameObject combinationPanel1;
    [SerializeField] 
    private GameObject combinationPanel2;

    [Space(13)]
    
    [SerializeField] 
    private Button finishButton;
    [SerializeField] 
    private GameObject finishPanel;

    [Space(13)]
    
    [SerializeField] 
    private Slider progressSlider;
    [SerializeField] 
    private GameObject winPanel;

    private int correctIndex;
    private int selectedIndex = 6;
    private const string PLAYER_PREFS_PROGRESS = "PLAYER_PREFS_PROGRESS";

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(PLAYER_PREFS_PROGRESS, 0) == 75)
        {
            this.gameObject.SetActive(false);
            winPanel.SetActive(true);
            PlayerPrefs.SetInt(PLAYER_PREFS_PROGRESS, 0);
        }
        else
        {
            progressSlider.value = PlayerPrefs.GetInt(PLAYER_PREFS_PROGRESS, 0);
        }
        
        SetCombinationSprite();

        selectedIndex = 6;
        SetButtonColor();
        
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (finishButton != null)
        {
            finishButton.onClick.RemoveAllListeners();
            finishButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                finishPanel.SetActive(true);
            });
        }

        if (answerButton[0] != null)
        {
            answerButton[0].onClick.RemoveAllListeners();
            answerButton[0].onClick.AddListener(() =>
            {
                selectedIndex = 0;
                SetButtonColor();
            });
        }
        
        if (answerButton[1] != null)
        {
            answerButton[1].onClick.RemoveAllListeners();
            answerButton[1].onClick.AddListener(() =>
            {
                selectedIndex = 1;
                SetButtonColor();
            });
        }
        
        if (answerButton[2] != null)
        {
            answerButton[2].onClick.RemoveAllListeners();
            answerButton[2].onClick.AddListener(() =>
            {
                selectedIndex = 2;
                SetButtonColor();
            });
        }
        
        if (answerButton[3] != null)
        {
            answerButton[3].onClick.RemoveAllListeners();
            answerButton[3].onClick.AddListener(() =>
            {
                selectedIndex = 3;
                SetButtonColor();
            });
        }
        
        if (answerButton[4] != null)
        {
            answerButton[4].onClick.RemoveAllListeners();
            answerButton[4].onClick.AddListener(() =>
            {
                selectedIndex = 4;
                SetButtonColor();
            });
        }

        if (nextButton != null)
        {
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(() =>
            {
                if (selectedIndex == correctIndex)
                {
                    PlayerPrefs.SetInt(PLAYER_PREFS_PROGRESS, PlayerPrefs.GetInt(PLAYER_PREFS_PROGRESS,0) + 5);
                    
                    int randomPanel = Random.Range(0, 2);
                    
                    switch (randomPanel)
                    {
                        case 0:
                            this.gameObject.SetActive(false);
                            combinationPanel1.SetActive(true);
                            break;
                        case 1:
                            this.gameObject.SetActive(false);
                            combinationPanel2.SetActive(true);
                            break;
                        default:
                            this.gameObject.SetActive(false);
                            combinationPanel1.SetActive(true);
                            break;
                    }
                }
                else
                {
                    int randomPanel = Random.Range(0, 2);
                    
                    switch (randomPanel)
                    {
                        case 0:
                            this.gameObject.SetActive(false);
                            combinationPanel1.SetActive(true);
                            break;
                        case 1:
                            this.gameObject.SetActive(false);
                            combinationPanel2.SetActive(true);
                            break;
                        default:
                            this.gameObject.SetActive(false);
                            combinationPanel1.SetActive(true);
                            break;
                    }
                }
            });
        }
    }

    private void SetCombinationSprite()
    {
        correctIndex = Random.Range(0, combinationSprite.Length);
        
        if (correctIndex == combinationSprite.Length)
        {
            SetCombinationSprite();
        }

        combinationImage.sprite = combinationSprite[correctIndex];
    }

    private void SetButtonColor()
    {
        switch (selectedIndex)
        {
            default:
                answerButton[0].GetComponent<Image>().color = defaultColor;
                answerButton[1].GetComponent<Image>().color = defaultColor;
                answerButton[2].GetComponent<Image>().color = defaultColor;
                answerButton[3].GetComponent<Image>().color = defaultColor;
                answerButton[4].GetComponent<Image>().color = defaultColor;
                break;
            case 0:
                answerButton[0].GetComponent<Image>().color = selectedColor;
                answerButton[1].GetComponent<Image>().color = defaultColor;
                answerButton[2].GetComponent<Image>().color = defaultColor;
                answerButton[3].GetComponent<Image>().color = defaultColor;
                answerButton[4].GetComponent<Image>().color = defaultColor;
                break;
            case 1:
                answerButton[0].GetComponent<Image>().color = defaultColor;
                answerButton[1].GetComponent<Image>().color = selectedColor;
                answerButton[2].GetComponent<Image>().color = defaultColor;
                answerButton[3].GetComponent<Image>().color = defaultColor;
                answerButton[4].GetComponent<Image>().color = defaultColor;
                break;
            case 2:
                answerButton[0].GetComponent<Image>().color = defaultColor;
                answerButton[1].GetComponent<Image>().color = defaultColor;
                answerButton[2].GetComponent<Image>().color = selectedColor;
                answerButton[3].GetComponent<Image>().color = defaultColor;
                answerButton[4].GetComponent<Image>().color = defaultColor;
                break;
            case 3:
                answerButton[0].GetComponent<Image>().color = defaultColor;
                answerButton[1].GetComponent<Image>().color = defaultColor;
                answerButton[2].GetComponent<Image>().color = defaultColor;
                answerButton[3].GetComponent<Image>().color = selectedColor;
                answerButton[4].GetComponent<Image>().color = defaultColor;
                break;
            case 4:
                answerButton[0].GetComponent<Image>().color = defaultColor;
                answerButton[1].GetComponent<Image>().color = defaultColor;
                answerButton[2].GetComponent<Image>().color = defaultColor;
                answerButton[3].GetComponent<Image>().color = defaultColor;
                answerButton[4].GetComponent<Image>().color = selectedColor;
                break;
        }
    }
}
