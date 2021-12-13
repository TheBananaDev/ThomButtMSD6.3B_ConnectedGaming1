using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5CanvasManager : MonoBehaviour
{
    private GameObject canv;
    private GameObject but1;
    private GameObject but2;
    private GameObject score1;
    private GameObject score2;
    private GameObject winner;
    private GameObject waiting;

    // Start is called before the first frame update
    void Start()
    {
        canv = GameObject.Find("Canvas");
        but1 = canv.transform.Find("MainMenu").Find("Player1But").gameObject;
        but2 = canv.transform.Find("MainMenu").Find("Player2But").gameObject;
        waiting = canv.transform.Find("GameplayMenu").Find("Waiting").gameObject;
        score1 = canv.transform.Find("GameplayMenu").Find("Player1Score").gameObject;
        score2 = canv.transform.Find("GameplayMenu").Find("Player2Score").gameObject;
        winner = canv.transform.Find("EndMenu").Find("Winner").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
