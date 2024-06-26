using UnityEngine;
using UnityEngine.UI;

public class NotesPanel : MonoBehaviour
{
    [SerializeField] 
    private Button createNoteButton;

    [SerializeField] 
    private GameObject createNotePanel;

    private void OnEnable()
    {
        if (createNoteButton != null)
        {
            createNoteButton.onClick.RemoveAllListeners();
            createNoteButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                createNotePanel.SetActive(true);
            });
        }
    }
}
