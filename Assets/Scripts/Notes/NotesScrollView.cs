using System.Collections.Generic;
using UnityEngine;

public class NotesScrollView : MonoBehaviour
{
    [SerializeField] private GameObject notesPrefab;

    [SerializeField] private Canvas canvas;

    private List<GameObject> notes = new List<GameObject>();
    private List<int> notesIndex;

    private void OnEnable()
    {
        ResetAllNotes();
        SpawnPrefabsInScrollView();
    }

    private void SpawnPrefabsInScrollView()
    {
        notesIndex = NotesData.Instance.GetNotesIndexList();

        for (int i = 0; i < notesIndex.Count; i++)
        {
            var note = Instantiate(notesPrefab, transform.position, Quaternion.identity);
            note.transform.SetParent(canvas.transform);
            note.transform.localScale = new Vector3(1, 1, 1);
            note.transform.SetParent(this.gameObject.transform);
            note.GetComponent<NotesPrefab>().SpawnPrefab(notesIndex[i]);
            notes.Add(note);
        }
    }

    private void ResetAllNotes()
    {
        if (notes != null)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                Destroy(notes[i]);
                notes.RemoveAt(i);
                ResetAllNotes();
            }
        }
    }
}
