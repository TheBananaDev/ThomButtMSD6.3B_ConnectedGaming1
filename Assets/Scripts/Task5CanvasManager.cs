using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task5CanvasManager : MonoBehaviour
{
    private GameObject canv;
    private GameObject but1;
    private GameObject but2;
    private GameObject score1;
    private GameObject score2;
    private GameObject winner;
    private GameObject waiting;

    private int player1Score;
    private int player2Score;
    private string playerWin;

    [System.NonSerialized]
    public int currState;

    private const string score1Text = "Player 1 Score: ";
    private const string score2Text = "Player 2 Score: ";

    // Start is called before the first frame update
    void Start()
    {
        //Gets a reference to all important UI elements
        canv = GameObject.Find("Canvas");
        but1 = canv.transform.Find("MainMenu").Find("Player1But").gameObject;
        but2 = canv.transform.Find("MainMenu").Find("Player2But").gameObject;
        waiting = canv.transform.Find("GameplayMenu").Find("Waiting").gameObject;
        score1 = canv.transform.Find("GameplayMenu").Find("Player1Score").gameObject;
        score2 = canv.transform.Find("GameplayMenu").Find("Player2Score").gameObject;
        winner = canv.transform.Find("EndMenu").Find("Winner").gameObject;

        //Ensures we start with the main menu
        ChangeMenu(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the visuals of the score
        score1.GetComponent<TextMeshProUGUI>().text = score1Text + player1Score.ToString();
        score2.GetComponent<TextMeshProUGUI>().text = score2Text + player2Score.ToString();

        if (player1Score > 10)
        {
            playerWin = "Player 1";
            ChangeMenu(3);
        }
        if (player2Score > 10)
        {
            playerWin = "Player 2";
            ChangeMenu(3);
        }
    }

    //Method to change menus
    private void ChangeMenu(int men)
    {
        switch (men)
        {
            //Main Menu
            case 0:
                canv.transform.Find("MainMenu").gameObject.SetActive(true);
                canv.transform.Find("GameplayMenu").gameObject.SetActive(false);
                canv.transform.Find("EndMenu").gameObject.SetActive(false);

                currState = 0;
                break;
            //Waiting
            case 1:
                canv.transform.Find("MainMenu").gameObject.SetActive(false);
                canv.transform.Find("GameplayMenu").gameObject.SetActive(true);
                canv.transform.Find("EndMenu").gameObject.SetActive(false);

                waiting.SetActive(true);
                score1.SetActive(false);
                score2.SetActive(false);

                currState = 1;
                break;
            //Playing
            case 2:
                canv.transform.Find("MainMenu").gameObject.SetActive(false);
                canv.transform.Find("GameplayMenu").gameObject.SetActive(true);
                canv.transform.Find("EndMenu").gameObject.SetActive(false);

                waiting.SetActive(false);
                score1.SetActive(true);
                score2.SetActive(true);

                currState = 2;
                break;
            //Ending
            case 3:
                canv.transform.Find("MainMenu").gameObject.SetActive(false);
                canv.transform.Find("GameplayMenu").gameObject.SetActive(false);
                canv.transform.Find("EndMenu").gameObject.SetActive(true);

                score1.GetComponent<TextMeshProUGUI>().text = playerWin;
                currState = 3;
                break;
            default:
                Debug.Log("Menu number doesn't exist");
                break;
        }
    }

    //Method to update the scores
    public void addScore(bool player)
    {
        if (player == false)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }
    }
}
