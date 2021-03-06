using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    private Rigidbody2D rb;
    public MagicGrow magic;
    public GameObject magicObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Player::Start cant find RigidBody2D </sadface>");
        }

    }
 // this is called at a fixed interval for use with physics objects like the RigidBody2D
    void FixedUpdate(){
        // check if user has pressed some input keys
        transform.rotation = Quaternion.Euler(0, 0, 0);//this prevents the player from rotatating;
        if(hitPoints <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//this resets the game
        }

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && magic.started == false)//the magic.started prevents the player from moving while casting magic
        {
            if(Input.GetAxisRaw("Horizontal") < 0)//needs to stay to keep the flip going left and right working
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
                magicObject.transform.localScale = new Vector2(-1, transform.localScale.y);
                magic.direction = -1;
            }
            else
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
                magicObject.transform.localScale = new Vector2(1, transform.localScale.y);
                magic.direction = 1;
            }


            ////everything from here
            // convert user input into world movement
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
            float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed;

            //assign world movements to a Veoctor2
            Vector2 directionOfMovement = new Vector2(horizontalMovement, verticalMovement);

            // apply movement to player's transform
            rb.AddForce(directionOfMovement);

            //////to here is the current movement script
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//this is so collisions with crystals dont happen
    {
        if (collision.gameObject.tag == "Magic")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
