using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public MagicGrow magic;
    public CircleCollider2D magicCollider;
    public bool teleportCompleted;

    private void Start()
    { 
    }

    // Update is called once per frame
    private void Update()
    {
        teleportCompleted = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Magic")
        {
            magic.maxLength += 3;
            player.transform.position = collision.transform.position;
            teleportCompleted = true;
        }
    }
}
