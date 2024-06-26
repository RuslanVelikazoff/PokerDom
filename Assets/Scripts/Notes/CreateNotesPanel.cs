using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNotesPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField notesNameInputField;
    [SerializeField] 
    private TMP_InputField notesDescriptionInputField;

    [SerializeField] 
    private Button createNoteButton;

    [SerializeField] 
    private GameObject notePanel;

    private void OnEnable()
    {
        notesNameInputField.text = string.Empty;
        notesDescriptionInputField.text = string.Empty;
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (createNoteButton != null)
        {
            createNoteButton.onClick.RemoveAllListeners();
            createNoteButton.onClick.AddListener(() =>
            {
                if (CreateNote())
                {
                    this.gameObject.SetActive(false);
                    notePanel.SetActive(true);
                }
            });
        }
    }

    private bool CreateNote()
    {
        if (notesNameInputField.text != string.Empty
            && notesDescriptionInputField.text != string.Empty)
        {
            NotesData.Instance.AddNewNotesName(notesNameInputField.text);
            NotesData.Instance.AddNewNotesDescription(notesDescriptionInputField.text);
            return true;
        }

        return false;
    }
}
