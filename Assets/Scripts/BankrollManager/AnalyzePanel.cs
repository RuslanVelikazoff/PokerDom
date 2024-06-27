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

        winText.text = $"Total win: {winAmount}$";
        loseText.text = $"Total lose: {loseAmount}$";
    }
}
