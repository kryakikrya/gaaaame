using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenShoots = 0.1f;
    [SerializeField] Image hpbar;
    private float hp = 1;

    bool canShoot = true;
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && canShoot == true) 
        { 
            StartCoroutine(Shooting());
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    IEnumerator Shooting()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShoots);
        canShoot = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            float damage = collision.GetComponent<EnemyBullet>().damage;
            hp -= damage;
            hpbar.fillAmount = hp;
            if (hp <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
