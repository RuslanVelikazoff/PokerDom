using System;
using TMPro;
using UnityEngine;

public class AnalyzePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;

    private float winAmount;
    private float loseAmount;

    private void OnEnable()
    {
        for (int i = 0; i < BetData.Instance.GetBetIndexList().Count; i++)
        {
            if (BetData.Instance.GetBetStatus(i))
            {
                winAmount += BetData.Instance.GetBetAmount(i);
            }
            else
            {
                loseAmount += BetData.Instance.GetBetAmount(i);
            }
        }

        winText.text = $"Total win: {Math.Round(winAmount, 2)}$";
        loseText.text = $"Total lose: {Math.Round(loseAmount, 2)}$";
    }
}
