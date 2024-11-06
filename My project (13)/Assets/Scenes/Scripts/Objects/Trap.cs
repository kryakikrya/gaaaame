using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] PlayerMovement player;
    private void Start()
    {
        if (damage == 0) damage = 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.GetDamage(damage);
        }
        Destroy(gameObject);
    }
}
