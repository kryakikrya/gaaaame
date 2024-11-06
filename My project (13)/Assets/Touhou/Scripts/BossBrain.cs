using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBrain : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    Transform currentPosition;
    [SerializeField] Image hpBar;
    float hp = 1;
    int states = 0;

    private void Start()
    {
        ChooseDirection();
    }
    private void Update()
    {
        if (currentPosition != null)
        {
            transform.position = Vector3.Slerp(transform.position, currentPosition.position, Time.deltaTime);
        }
    }
    private void ChooseDirection()
    {
        currentPosition = positions[Random.Range(0, positions.Length)];
        StartCoroutine(Relocating());
    }
    IEnumerator Relocating()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        ChooseDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            hp -= collision.GetComponent<PlayerBullet>().damage;
            hpBar.fillAmount = hp;
            Destroy(collision.gameObject);
            if (hp <= 0) Destroy(gameObject);
        }
    }
}
