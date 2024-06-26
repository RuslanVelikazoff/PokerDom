using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetSizeCalculatorPanel : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField potSizeInputField;
    [SerializeField] 
    private TMP_InputField currentAmountInputField;
    [SerializeField] 
    private TMP_InputField desiredAmountInputField;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI resultText;

    [Space(13)]
    
    [SerializeField] 
    private Button calculateButton;
    [SerializeField] 
    private Button clearButton;

    private int potSize;
    private int currentAmount;
    private int desiredAmount;

    private int numberOfBets;

    private void OnEnable()
    {
        Clear();
        ButtonClickAction();
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
    }

    private void Clear()
    {
        numberOfBets = 0;
        potSize = 0;
        currentAmount = 0;
        desiredAmount = 0;
        resultText.text = string.Empty;
        potSizeInputField.text = string.Empty;
        currentAmountInputField.text = string.Empty;
        desiredAmountInputField.text = string.Empty;
    }

    private void Calculate()
    {
        if (CorrectData())
        {
            while (currentAmount < desiredAmount)
            {
                currentAmount += potSize;
                numberOfBets++;
            }

            resultText.text = $"To achieve a balance, you need to make {numberOfBets} successful bets";
        }
    }

    private bool CorrectData()
    {
        if (potSizeInputField.text != string.Empty
            && currentAmountInputField.text != string.Empty
            && desiredAmountInputField.text != string.Empty)
        {
            potSize = Int32.Parse(potSizeInputField.text);
            currentAmount = Int32.Parse(currentAmountInputField.text);
            desiredAmount = Int32.Parse(desiredAmountInputField.text);

            if (potSize > 0 && currentAmount > 0 && desiredAmount > 0)
            {
                if (currentAmount > potSize)
                {
                    return true;
                }
                else
                {
                    resultText.text = "The current balance is lower than the current bet";
                    return false;
                }
            }
            else
            {
                resultText.text = "Data entered below zero";
                return false;
            }
        }
        else
        {
            resultText.text = "Not all data is filled in";
            return false;
        }
    }
}
