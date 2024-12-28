using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class Player : MonoBehaviour
{
    private const float speedStart = 6.0f;
    private float speed = 6.0f, mass = 1.0f;
    private int score = 0;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Camera cam;
    private bool status = true;
    public Text scoreText, timeText, statusText;
    private GiftGenerator giftGenerator;
    private HousesControl housesControl;
    void Start()
    {
        housesControl = GameObject.FindWithTag("HousesControl").GetComponent<HousesControl>();
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
        mass = 1.0f + (score * 0.1f);
        speed = speedStart / mass;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            Teleport();
        }
        statusText.text = "Status: " + (status ? "Saint Nicholas" : "Krampus");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gift")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Gift: " + score.ToString();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            int n = int.Parse(Regex.Match(collision.gameObject.name, @"\d+").Value) - 1;
            int houseGift = housesControl.houses[n].houseGift;
            if (score <= houseGift)
            {
                houseGift -= score;
                score = 0;
            }
            else
            {
                score -= houseGift;
                houseGift = 0;
            }
            scoreText.text = "Gift: " + score.ToString();
            housesControl.houses[n].houseGift = houseGift;
            housesControl.houses[n].houseText.text = houseGift.ToString();
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
        statusText.text = "Status: " + (status ? "Saint Nicholas" : "Krampus");
    }
}