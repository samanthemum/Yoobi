using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPerson : MonoBehaviour
{
    public GameObject Player;
    public MagicGrow Magic;
    public GameObject cameraObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v1 = Player.transform.position;
        cameraObject.transform.position = new Vector3(v1.x,v1.y+3.5f,1f);
        if (Magic.started == false)
        {
            Vector2 v = Player.transform.position;
            transform.position = new Vector2(v.x,v.y);
        }
    }
}
