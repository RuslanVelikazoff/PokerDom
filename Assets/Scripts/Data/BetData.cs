using System.Collections.Generic;
using UnityEngine;

public class BetData : MonoBehaviour
{
    public static BetData Instance { get; private set; }

    private const string SaveKey = "MainSaveBet";
    
    public List<float> _betAmount;
    public List<string> _betNotes;
    public List<bool> _betWin;

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

        _betAmount = data.betAmount;
        _betNotes = data.betNotes;
        _betWin = data.betWin;
        
        Debug.Log("Bet data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Bet data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            betAmount = _betAmount,
            betNotes = _betNotes,
            betWin = _betWin
        };

        return data;
    }

    #region GetMethods

    public float GetBetAmount(int index)
    {
        return _betAmount[index];
    }

    public bool GetBetStatus(int index)
    {
        return _betWin[index];
    }

    public List<int> GetBetIndexList()
    {
        List<int> index = new List<int>();

        for (int i = 0; i < _betAmount.Count; i++)
        {
            index.Add(i);
        }

        return index;
    }

    #endregion

    #region AddBet

    public void AddBetAmount(float amount)
    {
        _betAmount.Add(amount);
    }

    public void AddBetNotes(string notes)
    {
        _betNotes.Add(notes);
    }

    public void AddBetStatus(bool status)
    {
        _betWin.Add(status);
        Save();
    }

    #endregion

    public void DeleteBet(int index)
    {
        _betAmount.RemoveAt(index);
        _betNotes.RemoveAt(index);
        _betWin.RemoveAt(index);
    }
}
