using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;

    // The master lists of all data in the software
    public List<UserProfile> allUsers = new List<UserProfile>();
    public List<WeldAssignment> allAssignments = new List<WeldAssignment>();

    private string savePath;

    void Awake()
    {
        Instance = this;
        // This saves data to the hidden Windows AppData folder so it is secure
        savePath = Application.persistentDataPath + "/WeldingLMS_Database/";
        if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

        LoadDatabase(); // Load everything the second the app starts
    }

    public void SaveDatabase()
    {
        // Convert our C# lists into JSON text and write them to the hard drive
        string usersJson = JsonUtility.ToJson(new SerializationWrapper<UserProfile>(allUsers), true);
        File.WriteAllText(savePath + "users.json", usersJson);

        string assignmentsJson = JsonUtility.ToJson(new SerializationWrapper<WeldAssignment>(allAssignments), true);
        File.WriteAllText(savePath + "assignments.json", assignmentsJson);

        Debug.Log("Database Saved Successfully to: " + savePath);
    }

    public void LoadDatabase()
    {
        if (File.Exists(savePath + "users.json"))
        {
            string json = File.ReadAllText(savePath + "users.json");
            allUsers = JsonUtility.FromJson<SerializationWrapper<UserProfile>>(json).targetList;
        }

        if (File.Exists(savePath + "assignments.json"))
        {
            string json = File.ReadAllText(savePath + "assignments.json");
            allAssignments = JsonUtility.FromJson<SerializationWrapper<WeldAssignment>>(json).targetList;
        }
    }
}

// Unity needs this tiny wrapper class to save Lists properly
[System.Serializable]
public class SerializationWrapper<T>
{
    public List<T> targetList;
    public SerializationWrapper(List<T> list) { targetList = list; }
}