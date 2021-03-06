using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is used to determine how enemies move
public class enemyMovement : MonoBehaviour
{
    private Rigidbody2D enemy;
    public GameObject player;
    public Animator EnemyAnimator;
    public float direction; //direction = -1 for left, direction = 1 for rights
    public float maxX = 0; //the max x coordinate the enemy is allowed to move
    public float minX = -1; //the min x coordinate the enemy will move
    public float speed; //the speed of the character 
    private float fieldOfVision = 5; //constant representing enemies field of vision
    private int airspeed;
    private bool inair;
    private float pasty;
    public bool canSee;
    public PauseScript pauseScreen;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        speed = 5;
        direction = 1;
        inair = true;
        airspeed = 0;
        pasty = enemy.position.y;
        maxX = maxX+ enemy.position.x;
        minX = minX + enemy.position.x;
        canSee = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkFall();
        float yvelocity = 0;
        if (inair)
        {
            characterInAir();
            yvelocity = airspeed;
        }

        if (canSee)//if the enemy can see the player
        {
            enemy.velocity = new Vector2(speed*direction, yvelocity);
        }
        else
        {
            if(checkMin() && direction == -1)
            {
                direction *= -1;
            }
            if(checkMax() && direction == 1)
            {
                direction *= -1;
            }

            if (!pauseScreen.pause)
            {
                enemy.velocity = new Vector2(speed * direction, yvelocity);
                EnemyAnimator.SetFloat("direction", direction);
            }
            else
            {
                enemy.velocity = new Vector2(0, 0);
            }
        }
        
    }

    //NOTE: currently this method only takes into account x values. I'd like to develop a more complex version that involves y later.
    void checkSight() //method which tests if the enemy can "see" the player
    {
        if(direction == -1 && enemy.position.x-player.transform.position.x <= fieldOfVision && enemy.position.x - player.transform.position.x >= 0)
        {
            canSee = true;
        }
        if (direction == -1 && enemy.position.x - player.transform.position.x >= -1*fieldOfVision && enemy.position.x - player.transform.position.x <= 0)
        {
            canSee = true;
        }
    }

    bool checkMin() //checks to see if the enemy is at its minimum position
    {
        if (enemy.position.x <= minX)
        {
            return true;
        }
        return false;
    
    } 

    bool checkMax() //checks to see if the enemy is at its maximum position
    {
        if (enemy.position.x >= maxX)
        {
            return true;
        }
        return false;
    }

    private void characterInAir()
    {
        airspeed--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inair = false;
        airspeed = 0;
        if(collision.gameObject.tag == "Magic")
        {
            direction *= -1;
            enemy.velocity = new Vector2(speed * direction, 0);
            canSee = false;
        }
    }

    private void checkFall()//a method to check if the character is falling
    {
        if (enemy.position.y-pasty<-.25)
        {
            inair = true;
        }
        pasty = enemy.position.y;
    }
}
