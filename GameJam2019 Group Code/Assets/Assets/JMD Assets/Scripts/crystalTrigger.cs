using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class crystalTrigger : MonoBehaviour
{
    public TilemapCollider2D tmap;
    public TilemapRenderer tRender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MAgic")
        {
            tRender.enabled = !tRender.enabled;
            tmap.enabled = !tmap.enabled;//togle it
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MAgic")
        {
            tRender.enabled = !tRender.enabled;
            tmap.enabled = !tmap.enabled;//togle it
        }
        
    }
}
