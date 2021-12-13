using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private float player1PivotPos;
    private float player2PivotPos;

    private Task5CanvasManager canvManInst;
    private Task5Database database;

    void Start()
    {
        canvManInst = gameObject.GetComponent<Task5CanvasManager>();
        database = gameObject.GetComponent<Task5Database>();
        displayPlayers(false, false);
    }

    // Update is called once per frame
    void Update()
    {
        //Calculates distance and increments score when exceeded
        if (player1.transform.position.y > player1PivotPos + 2 || player1.transform.position.y < player1PivotPos - 2)
        {
            canvManInst.addScore(false);
            player1PivotPos = player1.transform.position.y;
        }
        if (player2.transform.position.y > player2PivotPos + 2 || player2.transform.position.y < player2PivotPos - 2)
        {
            canvManInst.addScore(true);
            player2PivotPos = player2.transform.position.y;
        }
    }

    //Controls the display of the player game objects
    public void displayPlayers(bool play1, bool play2)
    {
        player1.SetActive(play1);
        player2.SetActive(play2);
    }
    public void displayPlay1(bool disp)
    {
        player1.SetActive(disp);
        double[] pos = new double[2];
        pos[0] = player1.transform.position.x;
        pos[1] = player1.transform.position.y;
        database.addPlayer1("Circle", pos, System.DateTime.Now.ToString());
        StartCoroutine(updatePlayer1Pos());
    }
    public void displayPlay2(bool disp)
    {
        player2.SetActive(disp);
        double[] pos = new double[2];
        pos[0] = player2.transform.position.x;
        pos[1] = player2.transform.position.y;
        database.addPlayer2("Square", pos, System.DateTime.Now.ToString());
    }

    //Sets which player will be controlled in this instance
    public void setActivePlayer(bool play)
    {
        if (play == false)
        {
            Destroy(player2.GetComponent<PlayerControl>());
        }
        else if (play == true)
        {
            Destroy(player1.GetComponent<PlayerControl>());
        }
    }

    //Coroutines that update the positions of each player constantly
    private IEnumerator updatePlayer1Pos()
    {
        while (player1.activeSelf == true)
        {
            double[] pos = new double[2];
            pos[0] = player1.transform.position.x;
            pos[1] = player1.transform.position.y;
            database.updatePosPlayer1(pos);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator updatePlayer2Pos()
    {
        while (player2.activeSelf == true)
        {
            double[] pos = new double[2];
            pos[0] = player2.transform.position.x;
            pos[1] = player2.transform.position.y;
            database.updatePosPlayer2(pos);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
