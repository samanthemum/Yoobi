using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGrow : MonoBehaviour
{
    public float speed;
    public int maxLength;
    public SpriteRenderer MagicAsset;
    public CircleCollider2D MagicTrigger;
    public bool started;
    public int direction;
    // Start is called before the first frame update
    private void Start()
    {
        MagicAsset.enabled = false;
        started = false;
        direction = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            MagicAsset.enabled = true;
            MagicTrigger.enabled = true;
            started = true;
            Vector2 v = MagicAsset.size;
            if (v.x < maxLength)
            {
                //Debug.Log("resizing");
                MagicAsset.size = new Vector2(v.x + speed, v.y);
                MagicTrigger.offset = new Vector2(v.x + direction*speed, MagicTrigger.offset.y); 
            }
            else
            {
                MagicAsset.size = v;
            }
        }
        else
        {
            MagicAsset.enabled = false;
            MagicAsset.size = new Vector2(0.32f,0.32f);
            started = false;
            maxLength = 3;
            MagicTrigger.offset = new Vector2(.16f, 0);
            MagicTrigger.enabled = false;
        }
    }

    


}
