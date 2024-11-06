using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerMovement player;
    public Rigidbody2D rb;
    public float fanForce = 100f;
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        rb.AddForce(Vector2.up * (fanForce / (distance * distance)));
        Debug.Log((fanForce / (distance * distance)));
    }
}
//fanForce / (1 + distance * distance)
