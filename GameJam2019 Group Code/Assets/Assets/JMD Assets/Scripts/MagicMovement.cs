using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Player::Start cant find RigidBody2D </sadface>");
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if user has pressed some input keys
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.X))
        {

            // convert user input into world movement
            float horizontalMovement = 0;
            float verticalMovement = 0;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                horizontalMovement = -1 * moveSpeed;
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                horizontalMovement = 1 * moveSpeed;
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                verticalMovement = 1 * moveSpeed;
            }
            else
            {
                verticalMovement = -1 * moveSpeed;
            }
            

            //assign world movements to a Veoctor2
            Vector2 directionOfMovement = new Vector2(horizontalMovement, verticalMovement);

            // apply movement to player's transform
            rb.AddForce(directionOfMovement);
        }
    }
}
