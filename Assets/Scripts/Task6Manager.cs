using Firebase.Extensions;
using Firebase.Storage;
using TMPro;
using UnityEngine;

public class Task6Manager : MonoBehaviour
{
    public GameObject squareInst;
    public GameObject circleInst;
    public GameObject titleText;

    void Start()
    {
        //Gets the references in firebase storage
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference squareRef = storage.GetReferenceFromUrl("gs://connectedgamingassignment.appspot.com/Green_square.png");
        StorageReference circleRef = storage.GetReferenceFromUrl("gs://connectedgamingassignment.appspot.com/circle.png");
        TextMeshProUGUI text = titleText.GetComponent<TextMeshProUGUI>();

        const long maxAllowedSize = 1 * 1024 * 1024;
        text.text = "";
        //Downloads the square image
        squareRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task1 => {
            if (task1.IsFaulted || task1.IsCanceled)
            {
                Debug.LogException(task1.Exception);
                text.text += "Download 1 unsuccessful";
                // Uh-oh, an error occurred!
            }
            else
            {
                //Turns the image into a byte stream so it can be processed
                byte[] fileContents1 = task1.Result;
                Debug.Log("Finished downloading!");
                text.text += "Download 1 successful";

                //Converts the byte stream to a Texture2D component
                Texture2D textSquare = new Texture2D(1024, 1024);
                textSquare.LoadImage(fileContents1);
                //Sets the created Texture2D into a sprite to be rendered on screen
                Sprite spriteSqr = Sprite.Create(textSquare, new Rect(0f,0f,1024f,1024f), new Vector2(0, 0), 100f);
                squareInst.GetComponent<SpriteRenderer>().sprite = spriteSqr;
            }
        });

        //Downloads the circle imge
        circleRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task2 => {
            if (task2.IsFaulted || task2.IsCanceled)
            {
                Debug.LogException(task2.Exception);
                text.text += "Download 2 unsuccessful";
                // Uh-oh, an error occurred!
            }
            else
            {
                //Turns the image into a byte stream so it can be processed
                byte[] fileContents2 = task2.Result;
                Debug.Log("Finished downloading!");
                text.text += "Download 2 successful";

                //Converts the byte stream to a Texture2D component
                Texture2D textCircle = new Texture2D(1024, 1024);
                textCircle.LoadImage(fileContents2);
                //Sets the created Texture2D into a sprite to be rendered on screen
                Sprite spriteCrl = Sprite.Create(textCircle, new Rect(0f, 0f, 1024f, 1024f), new Vector2(0, 0), 100f);
                circleInst.GetComponent<SpriteRenderer>().sprite = spriteCrl;
            }
        });
    }
}
