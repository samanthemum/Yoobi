using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//HOMEGROWN PHYSICS BABEY
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool inair; //boolean to see if the player is in the air
    public bool crouch;
    public int airspeed;
    public float pasty;
    public bool hitEnemy;
    private float move;
    public float bouncebackx;
    public float bouncebacky;
    public Animator spriteAnimator;
    public PauseScript pauseScreen;
    public PlayerHealth health;


    private Rigidbody2D player;
    private Rigidbody2D enemy;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        speed = 10;
        bouncebackx = -20;
        bouncebacky = 10;
        inair = true;
        pasty = player.position.y;
        hitEnemy = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pauseScreen.pause&&health.lives>0)
        {
            move = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float yvelocity = 0;
            player.rotation = 0;
            player.angularVelocity = 0;
            if (vertical == 1 && !inair)
            {
                inair = true;
                airspeed = 20;
            }
            else if (vertical == -1)
            {
                crouch = true;
                move = 0;
            }
            else
            {
                crouch = false;
            }

            if (inair)
            {
                characterInAir();
                yvelocity = airspeed;
            }
            //if (hitEnemy)
            //{
            //    bounceBack();
            //}
            //else
            //{
            player.velocity = new Vector2(speed * move, yvelocity);
           
            spriteAnimator.SetFloat("speed", Mathf.Abs(move));
            checkFall();
            //}
        }
        else
        {
            player.velocity = new Vector2(0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hitEnemy = true;
            enemy = collision.gameObject.GetComponent<Rigidbody2D>();
            bouncebackx = 2*enemy.velocity.x;
            bouncebacky = enemy.velocity.y;
        }
        else
        {
            hitEnemy = false;
            inair = false;
            airspeed = 0;
        }
    }

    //a method to handling the event when the playable character jumps
    private void characterInAir()
    {
        airspeed--;
    }

    private void checkFall()//a method to check if the character is falling
    {
        if (player.position.y - pasty < -.00001)
        {
            inair = true;
        }
        if(player.position.y == pasty)
        {
            inair = false;
            airspeed = 0;
        }
        pasty = player.position.y;
    }

    //TODO
    //I was working this method earlier and it was glitchy as heck
    //It'll be fine later but this will control the player if they run into an object
    /*
    private void bounceBack()
    {
        float xvelocity = bouncebackx;
        float yvelocity = bouncebacky + airspeed;
        player.velocity = new Vector2(xvelocity, yvelocity);

        if (bouncebackx < 0)
            bouncebackx += 2;
        else if (bouncebackx > 0)
            bouncebackx -= 2;
        else
            hitEnemy = false;

        if (bouncebacky < 0)
            bouncebacky += 1;
        else if (bouncebacky > 0)
            bouncebacky -= 1;
    }
    
    */

}