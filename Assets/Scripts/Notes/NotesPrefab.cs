using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotesPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI notesNameText;
    [SerializeField] 
    private Button notesButton;

    [SerializeField] 
    private Button deleteButton;

    public void SpawnPrefab(int index)
    {
        notesNameText.text = NotesData.Instance.GetNotesName(index);

        ButtonClickAction(index);
    }

    private void ButtonClickAction(int index)
    {
        if (notesButton != null)
        {
            notesButton.onClick.RemoveAllListeners();
            notesButton.onClick.AddListener(() =>
            {
                EditNotesPanel.Instance.OpenEditNotesPanel(index);
            });
        }

        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                NotesData.Instance.DeleteNote(index);
                GameObject notesScrollView = FindObjectOfType<NotesScrollView>().gameObject;
                notesScrollView.SetActive(false);
                notesScrollView.SetActive(true);
            });
        }
    }
}
