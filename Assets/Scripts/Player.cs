using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private float speed = 6.0f, mass = 1.0f;
    private int score = 0;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Camera cam;
    private bool status = true;
    public Text scoreText, timeText, statusText;
    private GiftGenerator giftGenerator;
    void Start()
    {
        giftGenerator = GameObject.FindWithTag("GiftGenerator").GetComponent<GiftGenerator>();
        cam = Camera.main;
        rb = this.GetComponent<Rigidbody2D>();
        score = 0;
        scoreText.text = "Gift: " + score.ToString();
    }
    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
        rb.mass = mass;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Teleport();
        }
        statusText.text = "Status: " + (status ? "Santa" : "Krampus");
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
        if (transform.position.y < 5.0f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 20.0f);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 20.0f, cam.transform.position.z);
            CangeStatus(false);
            giftGenerator.Spawn(2);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 20.0f);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 20.0f, cam.transform.position.z);
            CangeStatus(status = true);
        }
    }
    void CangeStatus(bool status)
    {
        this.status = status;
        statusText.text = "Status: " + (status ? "Santa" : "Krampus");
    }
}