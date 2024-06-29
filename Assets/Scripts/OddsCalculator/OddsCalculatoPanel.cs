using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class OddsCalculatoPanel : MonoBehaviour
{
    [SerializeField] private Button[] cardTableButton;
    [SerializeField] private bool[] cardTableSelected;

    [SerializeField] private Button[] cardHandButton;
    [SerializeField] private bool[] cardHandSelected;

    [SerializeField] private Sprite cardCoverSprite;

    [SerializeField] private CardSelectPanel selectedCardPanel;

    [SerializeField] private Button calculateButton;
    [SerializeField] private Button clearButton;

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color winColor;
    [SerializeField] private Color errorColor;
    

    private void OnEnable()
    {
        for (int i = 0; i < cardTableButton.Length; i++)
        {
            if (cardTableButton[i].GetComponent<Image>().sprite != cardCoverSprite)
            {
                cardTableSelected[i] = true;
            }
            else
            {
                cardTableSelected[i] = false;
            }
        }

        for (int i = 0; i < cardHandButton.Length; i++)
        {
            if (cardHandButton[i].GetComponent<Image>().sprite != cardCoverSprite)
            {
                cardHandSelected[i] = true;
            }
            else
            {
                cardHandSelected[i] = false;
            }
        }

        ButtonClickAction();
        resultText.text = "You";
        resultText.color = defaultColor;
    }

    private void ButtonClickAction()
    {
        if (clearButton != null)
        {
            clearButton.onClick.RemoveAllListeners();
            clearButton.onClick.AddListener(() =>
            {
                Clear();
            });
        }

        if (calculateButton != null)
        {
            calculateButton.onClick.RemoveAllListeners();
            calculateButton.onClick.AddListener(() =>
            {
                Calculate();
            });
        }

        if (cardTableButton[0] != null)
        {
            cardTableButton[0].onClick.RemoveAllListeners();
            cardTableButton[0].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardTableButton[0]);
            });
        }
        
        if (cardTableButton[1] != null)
        {
            cardTableButton[1].onClick.RemoveAllListeners();
            cardTableButton[1].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardTableButton[1]);
            });
        }
        
        if (cardTableButton[2] != null)
        {
            cardTableButton[2].onClick.RemoveAllListeners();
            cardTableButton[2].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardTableButton[2]);
            });
        }
        
        if (cardTableButton[3] != null)
        {
            cardTableButton[3].onClick.RemoveAllListeners();
            cardTableButton[3].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardTableButton[3]);
            });
        }
        
        if (cardTableButton[4] != null)
        {
            cardTableButton[4].onClick.RemoveAllListeners();
            cardTableButton[4].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardTableButton[4]);
            });
        }

        if (cardHandButton[0] != null)
        {
            cardHandButton[0].onClick.RemoveAllListeners();
            cardHandButton[0].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardHandButton[0]);
            });
        }
        
        if (cardHandButton[1] != null)
        {
            cardHandButton[1].onClick.RemoveAllListeners();
            cardHandButton[1].onClick.AddListener(() =>
            {
                selectedCardPanel.OpenSelectPanel(cardHandButton[1]);
            });
        }
    }

    private void Calculate()
    {
        bool dataEntered = false;

        for (int i = 0; i < cardTableSelected.Length; i++)
        {
            if (!cardTableSelected[i])
            {
                dataEntered = false;
                resultText.text = "Not all cards are selected";
                resultText.color = errorColor;
                break;
            }
            else
            {
                dataEntered = true;
            }
        }

        for (int i = 0; i < cardHandSelected.Length; i++)
        {
            if (!cardHandSelected[i])
            {
                dataEntered = false;
                resultText.text = "Not all cards are selected";
                resultText.color = errorColor;
                break;
            }
            else
            {
                dataEntered = true;
            }
        }

        if (dataEntered)
        {
            float winningPercent = Random.Range(0f, 100f);
            resultText.text = Math.Round(winningPercent, 1) + "%";
            resultText.color = winColor;
        }
    }

    private void Clear()
    {
        selectedCardPanel.ClearAllCards();
        resultText.text = "You";
        resultText.color = defaultColor;

        for (int i = 0; i < cardHandButton.Length; i++)
        {
            cardHandButton[i].GetComponent<Image>().sprite = cardCoverSprite;
            cardHandSelected[i] = false;
        }

        for (int i = 0; i < cardTableButton.Length; i++)
        {
            cardTableButton[i].GetComponent<Image>().sprite = cardCoverSprite;
            cardTableSelected[i] = false;
        }
    }
}
