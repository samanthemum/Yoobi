using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAlternate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public MagicAlternate magic;
    public CircleCollider2D magicCollider;
    public bool teleport = false;
    public float positionConstantX = 1.5f;
    public float positionConstantY = 1f;
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Magic")
        {
            if (magic.directionAlt < 0)
            {
                player.transform.position = new Vector2(collision.transform.position.x-positionConstantX,  collision.transform.position.y+positionConstantY);
            }

            else
            {
                player.transform.position = new Vector2(collision.transform.position.x + positionConstantX, collision.transform.position.y+positionConstantY);
            }

        }
    }
}
