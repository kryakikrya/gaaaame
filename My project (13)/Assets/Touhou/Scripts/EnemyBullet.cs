using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] public float damage = 0.05f;
    private void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }
}
