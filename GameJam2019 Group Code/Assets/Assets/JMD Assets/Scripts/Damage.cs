using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public player p;
    public float dmgAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        p.hitPoints -= dmgAmount;
    }
}
