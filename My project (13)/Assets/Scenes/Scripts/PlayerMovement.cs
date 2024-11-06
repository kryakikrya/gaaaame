using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 moveVector;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpForce = 4f;
    private bool isGrounded;
    public bool isFlying;
    [SerializeField] Animator anim;
    [SerializeField] Transform groundPos;
    [SerializeField] LayerMask groundLayer;
    public int lives;

    private void Start()
    {
        lives = 10;
        isFlying = true;
    }
    private void FixedUpdate()
    {
        Walk();
        CheckGround();
        Jump();
    }
    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
        if (moveVector.x < 0) transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
        if (moveVector.x > 0) transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && (isGrounded || isFlying))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(Vector2.up * jumpForce * 10, ForceMode2D.Impulse);
        }
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundPos.position, 0.3f, groundLayer);
        isGrounded = collider.Length > 0;
    }
    public void GetDamage(int damage)
    {
        lives -= damage;
        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void MorphCube()
    {
        isFlying = false;
    }
    public void MorphFly()
    {
        isFlying = true;
    }
}

