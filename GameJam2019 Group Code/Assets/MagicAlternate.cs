using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAlternate : MonoBehaviour
{
    public float magicSpeed;
    public int maxLength;
    public SpriteRenderer MagicAssetAlt;
    public CircleCollider2D MagicTrigger;
    public bool startedAlt;
    public int directionAlt;
    private int duration = 30;
    public int index = 0;
    public TeleportAlternate teleportation;
    public Rigidbody2D player;
    public SpriteRenderer[] magicSprites;
    public SpriteRenderer MagicAsset1;
    public SpriteRenderer MagicAsset2;
    public SpriteRenderer MagicAsset3;
    public SpriteRenderer MagicAsset4;
    public SpriteRenderer MagicAsset5;
    public SpriteRenderer MagicAsset6;
    public SpriteRenderer MagicAsset7;
    public SpriteRenderer MagicAsset8;
    public SpriteRenderer MagicAsset9;
    public SpriteRenderer MagicAsset10;
    public SpriteRenderer MagicAsset11;
    public SpriteRenderer MagicAsset12;
    public SpriteRenderer MagicAsset13;
    public SpriteRenderer MagicAsset14;
    public SpriteRenderer MagicAsset15;
    public SpriteRenderer MagicAsset16;
    public SpriteRenderer MagicAsset17;
    public SpriteRenderer MagicAsset18;
    public SpriteRenderer MagicAsset19;
    public SpriteRenderer MagicAsset20;
    // Start is called before the first frame update
    private void Start()
    {
        MagicAssetAlt.enabled = false;
        magicSprites = new SpriteRenderer [20];
        magicSprites[0] = MagicAsset1;
        magicSprites[1] = MagicAsset2;
        magicSprites[2] = MagicAsset3;
        magicSprites[3] = MagicAsset4;
        magicSprites[4] = MagicAsset5;
        magicSprites[5] = MagicAsset6;
        magicSprites[6] = MagicAsset7;
        magicSprites[7] = MagicAsset8;
        magicSprites[8] = MagicAsset9;
        magicSprites[9] = MagicAsset10;
        magicSprites[10] = MagicAsset11;
        magicSprites[11] = MagicAsset12;
        magicSprites[12] = MagicAsset13;
        magicSprites[13] = MagicAsset14;
        magicSprites[14] = MagicAsset15;
        magicSprites[15] = MagicAsset16;
        magicSprites[16] = MagicAsset17;
        magicSprites[17] = MagicAsset18;
        magicSprites[18] = MagicAsset19;
        magicSprites[19] = MagicAsset20;
        for (int i = 0; i < magicSprites.Length; i++)
        {
            magicSprites[i].enabled = false;
            magicSprites[i].size = new Vector2(1, 1);
        }
        startedAlt = false;
        directionAlt = 1;
        magicSpeed = .1F;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            /*
            MagicAssetAlt.enabled = true;
            MagicAssetAlt.transform.position = new Vector2(MagicAssetAlt.transform.position.x + magicSpeed*directionAlt, MagicAssetAlt.transform.position.y);   
            duration--;
            if(duration == 0)
            {
                MagicAssetAlt.enabled = false;
                startedAlt = false;
                duration = 30;
                MagicAssetAlt.transform.position = new Vector2(player.position.x, player.position.y);
            }
            */
            if (index < 10) { 
                for(int i = 0; i < index; i++)
                    magicSprites[index].transform.position = new Vector2(player.position.x + directionAlt*index * (magicSprites[index].size.x / 2), player.position.y);
                    magicSprites[index].enabled = true;
                    index++;
                }
        }
        else
        {
            /*
            MagicAssetAlt.enabled = false;
            startedAlt = false;
            duration = 30;
            MagicAssetAlt.transform.position = new Vector2(player.position.x, player.position.y);
            */
            index = 0;
            for (int i = 0; i < 10; i++)
            {
                magicSprites[i].transform.position = new Vector2(player.position.x + directionAlt * index * (magicSprites[index].size.x / 2), player.position.y);
                magicSprites[i].enabled = false;
                magicSprites[i].size = new Vector2(1, 1);

            }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionAlt = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionAlt = -1;
        }
    }



}

