using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script manages the players health- should be attached to the asset representing the player
public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public Animator livesAnimator;
    public Animator spriteAnimator;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            lives--;
        }
        if (lives <= 0)
        {
            StartCoroutine(delayer(1));
            
        }
    }

    private void Update()
    {
        livesAnimator.SetInteger("lives", lives);
        spriteAnimator.SetInteger("lives", lives);
    }

    IEnumerator delayer(float waittime)
    {
        yield return new WaitForSecondsRealtime(waittime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//this resets the game
    }
}
