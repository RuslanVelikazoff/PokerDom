using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI taskNameText;

    [SerializeField] 
    private Button completeButton;
    [SerializeField]
    private Button uncompleteButton;

    [SerializeField] 
    private Button deleteButton;

    private int index;

    public void SpawnPrefab(int index)
    {
        this.index = index;
        taskNameText.text = TaskData.Instance.GetTaskName(index);
        ButtonClickAction();
        SetCompletedButton();
    }

    private void ButtonClickAction()
    {
        if (completeButton != null)
        {
            completeButton.onClick.RemoveAllListeners();
            completeButton.onClick.AddListener(() =>
            {
                TaskData.Instance.SetTaskCompleted(index, false);
                SetCompletedButton();
            });
        }

        if (uncompleteButton != null)
        {
            uncompleteButton.onClick.RemoveAllListeners();
            uncompleteButton.onClick.AddListener(() =>
            {
                TaskData.Instance.SetTaskCompleted(index, true);
                SetCompletedButton();
            });
        }

        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                TaskData.Instance.DeleteTask(index);
                GameObject taskScrollView = FindObjectOfType<TaskScrollView>().gameObject;
                taskScrollView.SetActive(false);
                taskScrollView.SetActive(true);
            });
        }
    }

    private void SetCompletedButton()
    {
        if (TaskData.Instance.GetTaskCompleted(index))
        {
            completeButton.gameObject.SetActive(true);
            uncompleteButton.gameObject.SetActive(false);
        }
        else
        {
            completeButton.gameObject.SetActive(false);
            uncompleteButton.gameObject.SetActive(true);
        }
    }
}
