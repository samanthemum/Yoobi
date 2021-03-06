using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script allows the camera to follow the player
public class followCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 displacement;
    void Start()
    {
        displacement = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + displacement;
    }
}
