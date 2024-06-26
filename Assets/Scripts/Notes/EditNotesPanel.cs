using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditNotesPanel : MonoBehaviour
{
    public static EditNotesPanel Instance { get; private set; }

    [SerializeField]
    private TMP_InputField notesNameInputField;
    [SerializeField] 
    private TMP_InputField notesDescriptionInputField;

    [SerializeField] 
    private Button saveButton;
    [SerializeField]
    private GameObject notesPanel;

    private int index;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void OpenEditNotesPanel(int index)
    {
        this.index = index;
        notesPanel.SetActive(false);
        this.gameObject.SetActive(true);
        notesNameInputField.text = NotesData.Instance.GetNotesName(index);
        notesDescriptionInputField.text = NotesData.Instance.GetNotesDescription(index);
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (saveButton != null)
        {
            saveButton.onClick.RemoveAllListeners();
            saveButton.onClick.AddListener(() =>
            {
                if (EditNotes(notesNameInputField.text, notesDescriptionInputField.text))
                {
                    this.gameObject.SetActive(false);
                    notesPanel.SetActive(true);
                }
            });
        }
    }

    private bool EditNotes(string newName, string newDescription)
    {
        if (notesNameInputField.text != string.Empty
            && notesDescriptionInputField.text != string.Empty)
        {
            NotesData.Instance.SetNotesName(index, notesNameInputField.text);
            NotesData.Instance.SetNotesDescription(index, notesDescriptionInputField.text);
            return true;
        }

        return false;
    }
}
