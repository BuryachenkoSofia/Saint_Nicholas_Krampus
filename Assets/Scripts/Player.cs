using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private float speed = 6.0f, mass = 1.0f;
    private int score = 0;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Text scoreText, timeText;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        score = 0;
        scoreText.text = "Gift: " + score.ToString();
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.mass = mass;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Gift")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Gift: " + score.ToString();
        }
    }
    void Teleport()
    {
        if (transform.position.y < 5)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 20.0f);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 20.0f);
        }
    }
}