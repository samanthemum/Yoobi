using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateWall : MonoBehaviour
{
    public TilemapCollider2D tmap;
    // Start is called before the first frame update
    void Start()
    {
        tmap.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
