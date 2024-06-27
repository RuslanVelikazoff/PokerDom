using System.Collections.Generic;

public class GameData
{
    //Notes
    public List<string> notesName;
    public List<string> notesDescription;
    
    //Task
    public List<string> taskName;
    public List<string> taskDescription;
    public List<bool> taskCompleted;
    
    //Bankroll Manager
    public List<float> betAmount;
    public List<string> betNotes;
    public List<bool> betWin;

    public GameData()
    {
        notesName = new List<string>();
        notesDescription = new List<string>();

        taskName = new List<string>();
        taskDescription = new List<string>();
        taskCompleted = new List<bool>();

        betAmount = new List<float>();
        betNotes = new List<string>();
        betWin = new List<bool>();
    }
}
