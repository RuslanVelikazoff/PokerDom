using UnityEngine;
using UnityEngine.UI;

public class CardSelectPanel : MonoBehaviour
{
    [SerializeField] private Button[] cardButton;
    [SerializeField] private Sprite[] cardSprite;
    [SerializeField] private Sprite cardCoverSprite;
    
    [SerializeField] private bool[] cardSelected;

    [SerializeField] private GameObject oddsCalculatorPanel;
    
    private Image cardImage;

    private void OnEnable()
    {
        for (int i = 0; i < cardSelected.Length; i++)
        {
            if (cardSelected[i])
            {
                cardButton[i].GetComponent<Image>().sprite = cardCoverSprite;
            }
            else
            {
                cardButton[i].GetComponent<Image>().sprite = cardSprite[i];
            }
        }
    }

    public void OpenSelectPanel(Button button)
    {
        cardImage = button.GetComponent<Image>();

        this.gameObject.SetActive(true);
    }

    public void SelectCard(int index)
    {
        if (!cardSelected[index])
        {
            cardImage.sprite = cardSprite[index];
            cardSelected[index] = true;

            this.gameObject.SetActive(false);

            oddsCalculatorPanel.SetActive(false);
            oddsCalculatorPanel.SetActive(true);
        }
    }

    public void ClearAllCards()
    {
        for (int i = 0; i < cardSelected.Length; i++)
        {
            cardSelected[i] = false;
        }
    }
}
