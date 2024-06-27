using System.Collections.Generic;
using UnityEngine;

public class TaskData : MonoBehaviour
{
    public static TaskData Instance { get; private set; }

    private const string SaveKey = "MainSaveTask";

    public List<string> _taskName;
    public List<string> _taskDescription;
    public List<bool> _taskCompleted;

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

        _taskName = data.taskName;
        _taskDescription = data.taskDescription;
        _taskCompleted = data.taskCompleted;
        
        Debug.Log("Task data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Task data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            taskName = _taskName,
            taskDescription = _taskDescription,
            taskCompleted = _taskCompleted
        };

        return data;
    }

    #region GetMethods

    public string GetTaskName(int index)
    {
        return _taskName[index];
    }

    public bool GetTaskCompleted(int index)
    {
        return _taskCompleted[index];
    }

    public List<int> GetTaskIndexList()
    {
        List<int> index = new List<int>();

        for (int i = 0; i < _taskName.Count; i++)
        {
            index.Add(i);
        }

        return index;
    }

    #endregion

    #region SetMethods

    public void SetTaskCompleted(int index, bool completed)
    {
        _taskCompleted[index] = completed;
        Save();
    }

    #endregion

    #region CreateTask

    public void AddTaskName(string name)
    {
        _taskName.Add(name);
    }

    public void AddTaskDescription(string description)
    {
        _taskDescription.Add(description);
    }

    public void AddTaskCompleted()
    {
        _taskCompleted.Add(false);
        Save();
    }

    #endregion

    public void DeleteTask(int index)
    {
        _taskName.RemoveAt(index);
        _taskDescription.RemoveAt(index);
        _taskCompleted.RemoveAt(index);
    }
}
