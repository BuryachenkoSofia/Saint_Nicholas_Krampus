using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private float time = 60.0f;
    public Text timeText;
    public GameObject losePanel;
    void Start()
    {
        switch (PlayerPrefs.GetInt("difficultyLevel"))
        {
            case 0:
                time = 600.0f;
                break;
            case 1:
                time = 60.0f;
                break;
            case 2:
                time = 60.0f;
                break;
            case 3:
                time = 60f;
                break;
            case 4:
                time = 60f;
                break;
            case 5:
                time = 60f;
                break;
        }
    }
    public void Update()
    {
        if (time <= 0)
        {
            time = 0;
            Time.timeScale = 0;
            losePanel.SetActive(true);
        }
        else
        {
            time -= Time.deltaTime;
        }
        timeText.text = "Time: " + ((int)time).ToString();
    }
}