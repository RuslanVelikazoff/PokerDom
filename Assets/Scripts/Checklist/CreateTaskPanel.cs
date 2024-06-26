using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateTaskPanel : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField nameTaskInputField;
    [SerializeField] 
    private TMP_InputField descriptionTaskInputField;

    [SerializeField] 
    private Button createTaskButton;

    [SerializeField] 
    private GameObject checklistPanel;

    private void OnEnable()
    {
        nameTaskInputField.text = string.Empty;
        descriptionTaskInputField.text = string.Empty;
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (createTaskButton != null)
        {
            createTaskButton.onClick.RemoveAllListeners();
            createTaskButton.onClick.AddListener(() =>
            {
                CreateTask();
            });
        }
    }

    private void CreateTask()
    {
        if (nameTaskInputField.text != string.Empty)
        {
            TaskData.Instance.AddTaskName(nameTaskInputField.text);
            TaskData.Instance.AddTaskDescription(descriptionTaskInputField.text);
            TaskData.Instance.AddTaskCompleted();
            this.gameObject.SetActive(false);
            checklistPanel.SetActive(true);
        }
    }
}
