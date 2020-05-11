using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public  string  filePath;

    void Start () {
        Debug.Log("DataHandler start");
        LoadNotes();

    }

    void LoadNotes() {
        string json = File.ReadAllText(filePath);
        // Debug.Log(json);
    }
}
