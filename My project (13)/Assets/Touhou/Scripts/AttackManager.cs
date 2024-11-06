using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] spps;
    public void Shoot()
    {
        for (int i = 0; i < spps.Length; i++)
        {
            Instantiate(bullet, spps[i].transform.position, Quaternion.identity);
        }

    }
}
