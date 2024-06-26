using UnityEngine;
using UnityEngine.UI;

public class ChecklistPanel : MonoBehaviour
{
    [SerializeField] 
    private Button addTaskButton;

    [SerializeField]
    private GameObject createTaskPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (addTaskButton != null)
        {
            addTaskButton.onClick.RemoveAllListeners();
            addTaskButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                createTaskPanel.SetActive(true);
            });
        }
    }
}
