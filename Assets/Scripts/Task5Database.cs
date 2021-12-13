using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Task5Database : MonoBehaviour
{
    DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        addNewPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        deletePlayers();
    }

    //Method to add generic player (dummy data)
    public void addNewPlayer()
    {
        PlayerData player = new PlayerData();
        string json = JsonUtility.ToJson(player);
        reference.Child("Objects").Child("Player").SetRawJsonValueAsync(json);
    }

    //Method to add a new player with values
    public void addNewPlayer(string i, string s, double[] p, string t)
    {
        PlayerData player = new PlayerData(i, s, p, t);
        string json = JsonUtility.ToJson(player);
        reference.Child("Objects").Child(i).SetRawJsonValueAsync(json);
    }

    //Method to update the position whilst the game is running
    private void updatePos()
    {

    }

    //Method to delete the players once the games stops
    private void deletePlayers()
    {
        reference.Child("Objects").RemoveValueAsync();  
    }
}

//Struct containing all the data that will be processed
public struct PlayerData
{
    public string instName;
    public string shapeName;
    public double[] instPos;
    public string instTime;

    public PlayerData(string i, string s, double[] p, string t)
    {
        this.instName = i;
        this.shapeName = s;
        this.instPos = p;
        this.instTime = t;
    }
}
