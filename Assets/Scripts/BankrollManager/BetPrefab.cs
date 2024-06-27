using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetPrefab : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI betText;

    [SerializeField] 
    private Color winColor;
    [SerializeField] 
    private Color loseColor;

    [SerializeField] 
    private Button deleteButton;

    private int index;

    public void SpawnPrefab(int index)
    {
        this.index = index;

        betText.text = "$" + Math.Round(BetData.Instance.GetBetAmount(index), 2);

        SetTextColor();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                BetData.Instance.DeleteBet(index);
                GameObject bankrollManagerPanel = FindObjectOfType<BankrollManagerPanel>().gameObject;
                bankrollManagerPanel.SetActive(false);
                bankrollManagerPanel.SetActive(true);
            });
        }
    }

    private void SetTextColor()
    {
        if (BetData.Instance.GetBetStatus(index))
        {
            betText.color = winColor;
        }
        else
        {
            betText.color = loseColor;
        }
    }
}
