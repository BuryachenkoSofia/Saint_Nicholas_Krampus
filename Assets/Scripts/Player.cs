using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class Player : MonoBehaviour
{
    private const float speedStart = 6.0f;
    private float speed = 6.0f, mass = 1.0f;
    private int score = 0;
    private int spawnN = 2;
    private bool status = true;
    private float lastTime;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Camera cam;
    private GiftGenerator giftGenerator;
    public HousesControl housesControl;
    private TutorialScript tutorialScript;
    [Header("Tutorial")]
    public bool isMove = false;
    public bool isSpace = false;
    public bool isGift = false;
    public bool isHouse = false;
    [Header("UI")]
    public Text scoreText;
    public Text timeText;
    public Text statusText;
    public Text levelText;

    private Animator animator;
    void Start()
    {
        housesControl = GameObject.FindWithTag("HousesControl").GetComponent<HousesControl>();
        giftGenerator = GameObject.FindWithTag("GiftGenerator").GetComponent<GiftGenerator>();
        if (PlayerPrefs.GetInt("difficultyLevel") == 0)
        {
            tutorialScript = this.GetComponent<TutorialScript>();
        }
        else
        {
            tutorialScript = null;
        }
        animator = GetComponent<Animator>();
        cam = Camera.main;
        rb = this.GetComponent<Rigidbody2D>();
        score = 0;
        scoreText.text = "Gift: " + score.ToString();
        DifficultyLevelSettings();
        if(PlayerPrefs.GetInt("difficultyLevel") != 0){
            switch(PlayerPrefs.GetInt("difficultyLevel")){
                case 1:
                    levelText.text = "Level: Begginer";
                    break;
                case 2:
                    levelText.text = "Level: Easy";
                    break;
                case 3:
                    levelText.text = "Level: Medium";
                    break;
                case 4:
                    levelText.text = "Level: Hard";
                    break;
                case 5:
                    levelText.text = "Level: Expert";
                    break;
            }
        }
        
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
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1 && Time.time >= lastTime + 0.5f)
        {
            Teleport();
            lastTime = Time.time;
            isSpace = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpace = false;
        }
        animator.SetBool("Krampus", !status);
        animator.SetFloat("Move", Mathf.Abs(movement.x) + Mathf.Abs(movement.y));
        if (Mathf.Abs(movement.x) + Mathf.Abs(movement.y) > 0.01)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gift")
        {
            if (PlayerPrefs.GetInt("difficultyLevel") == 0) {
                if(tutorialScript.stage == 2){
                    isGift = true;
                }
            }
            score++;
            scoreText.text = "Gift: " + score.ToString();
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            if (PlayerPrefs.GetInt("difficultyLevel") == 0) {
                if(tutorialScript.stage == 3){
                    isHouse = true;
                }
            }
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
            giftGenerator.Spawn(spawnN);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 20.0f);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 20.0f, cam.transform.position.z);
            CangeStatus(true);
        }
    }
    void CangeStatus(bool status)
    {
        this.status = status;
        statusText.text = "Status: " + (status ? "Saint Nicholas" : "Krampus");
    }
    void DifficultyLevelSettings()
    {
        switch (PlayerPrefs.GetInt("difficultyLevel"))
        {
            case 0:
                spawnN = 3;
                break;
            case 1:
                spawnN = 3;
                break;
            case 2:
                spawnN = 2;
                break;
            case 3:
                spawnN = 2;
                break;
            case 4:
                spawnN = 1;
                break;
            case 5:
                spawnN = 1;
                break;
        }
    }
}