using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class Task5Database : MonoBehaviour
{
    DatabaseReference reference;
    private Task5CanvasManager canvManInst;

    private string key1;
    private string key2;

    public Vector2 playerPos1;
    public Vector2 playerPos2;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        canvManInst = gameObject.GetComponent<Task5CanvasManager>();
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
        key1 = reference.Child("Objects").Push().Key;
        reference.Child("Objects").Child(key1).SetRawJsonValueAsync(json);
    }

    //Method to add the appropriate player with values
    public void addPlayer1(string s, double[] p, string t)
    {
        PlayerData player = new PlayerData("Player 1", s, p, t);
        string json = JsonUtility.ToJson(player);
        key1 = reference.Child("Objects").Push().Key;
        reference.Child("Objects").Child(key1).SetRawJsonValueAsync(json);
    }
    public void addPlayer2(string s, double[] p, string t)
    {
        PlayerData player = new PlayerData("Player 2", s, p, t);
        string json = JsonUtility.ToJson(player);
        key2 = reference.Child("Objects").Push().Key;
        reference.Child("Objects").Child(key2).SetRawJsonValueAsync(json);
    }

    //Method to check if the player is created in the database already
    public void checkIfPlayerExists()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Objects").GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                Debug.Log("Error when getting values from database");
             }
             else if (task.IsCompleted)
             {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Value != null)
                {
                    canvManInst.playerExists = true;
                }
                else
                {
                    canvManInst.playerExists = false;
                }
             }
         });
    }

    //Methods to get the positions of the players
    public void getPosPlayer1()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Objects/"+key1+"/instPos").GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Error when getting values from database");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.Value);

                playerPos1.x = (float)snapshot.Value;
            }
        });
    }
    public void getPosPlayer2()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Objects/" + key2 + "/instPos").GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Error when getting values from database");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.Value);

                playerPos2.x = (float)snapshot.Value;
            }
        });
    }

    //Method to update the position whilst the game is running
    public void updatePosPlayer1(double[] pos)
    {
        reference.Child("Objects").Child(key1).Child("instPos").SetValueAsync(pos);
    }
    public void updatePosPlayer2(double[] pos)
    {
        reference.Child("Objects").Child(key2).Child("instPos").SetValueAsync(pos);
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
