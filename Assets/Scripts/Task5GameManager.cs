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

    void Start()
    {
        canvManInst = gameObject.GetComponent<Task5CanvasManager>();
        player1.SetActive(false);
        player2.SetActive(false);
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
}
