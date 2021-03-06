using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TeleportAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D mc;
    public Teleport teleport;
    public SpriteRenderer teleportSprite;
    public Animator animator;

    void Start()
    {
        teleportSprite.enabled = false;
        teleportSprite.transform.position = mc.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        teleportSprite.transform.position = mc.position;
        if (teleport.teleportCompleted)
        {
            StartCoroutine(animation());
            teleportSprite.enabled = true;
        }
        animator.SetBool("teleport", teleport.teleportCompleted);
    }

    IEnumerator animation()
    {
        yield return new WaitForSecondsRealtime(.5f);
        teleportSprite.enabled = false;
    }
}
