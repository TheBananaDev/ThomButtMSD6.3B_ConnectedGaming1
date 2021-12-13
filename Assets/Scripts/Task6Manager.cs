using Firebase.Extensions;
using Firebase.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task6Manager : MonoBehaviour
{
    public GameObject squareInst;
    public GameObject circleInst;

    StorageReference storageRef;

    void Start()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference squareRef = storage.GetReferenceFromUrl("gs://connectedgamingassignment.appspot.com/square.png");
        StorageReference circleRef = storage.GetReferenceFromUrl("gs://connectedgamingassignment.appspot.com/circle.png");

        const long maxAllowedSize = 1 * 1024 * 1024;
        squareRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
                // Uh-oh, an error occurred!
            }
            else
            {
                byte[] fileContents = task.Result;
                Debug.Log("Finished downloading!");
            }
        });

        circleRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
                // Uh-oh, an error occurred!
            }
            else
            {
                byte[] fileContents = task.Result;
                Debug.Log("Finished downloading!");
            }
        });
    }
}
