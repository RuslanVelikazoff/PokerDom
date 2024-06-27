using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] 
    private Button yesButton;
    [SerializeField] 
    private Button noButton;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject combinationTrainerPanel1;
    [SerializeField] 
    private GameObject combinationTrainerPanel2;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (yesButton != null)
        {
            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (noButton != null)
        {
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);

                int randomPanel = Random.Range(0, 2);

                switch (randomPanel)
                {
                    default:
                        combinationTrainerPanel1.SetActive(true);
                        combinationTrainerPanel2.SetActive(false);
                        break;
                    case 0:
                        combinationTrainerPanel1.SetActive(true);
                        combinationTrainerPanel2.SetActive(false);
                        break;
                    case 1:
                        combinationTrainerPanel1.SetActive(false);
                        combinationTrainerPanel2.SetActive(true);
                        break;
                }
            });
        }
    }
}
