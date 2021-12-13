using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D charcont;
    // Start is called before the first frame update
    void Start()
    {
        charcont = this.gameObject.GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        charcont.velocity = new Vector3(4f * inputX, 4f * inputY);
    }
}
