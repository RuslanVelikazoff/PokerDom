using System;
using TMPro;
using UnityEngine;

public class BetPrefab : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI betText;

    [SerializeField] 
    private Color winColor;
    [SerializeField] 
    private Color loseColor;

    private int index;

    public void SpawnPrefab(int index)
    {
        this.index = index;

        betText.text = "$" + Math.Round(BetData.Instance.GetBetAmount(index));
        
        SetTextColor();
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
