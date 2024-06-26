using System.Collections.Generic;
using UnityEngine;

public class NotesData : MonoBehaviour
{
    public static NotesData Instance { get; private set; }

    private const string SaveKey = "MainSaveNotes";

    public List<string> _notesName;
    public List<string> _notesDescription;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _notesName = data.notesName;
        _notesDescription = data.notesDescription;
        
        Debug.Log("Notes data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Notes data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            notesName = _notesName,
            notesDescription = _notesDescription
        };

        return data;
    }
}
