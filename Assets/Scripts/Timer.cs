using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private float time = 60.0f;
    public Text timeText;
    public void Update()
    {
        if (time <= 0)
        {
            time=0;
            Time.timeScale = 0;
        }
        else
        {
            time -= Time.deltaTime;
        }
        timeText.text = "Time: " + ((int)time).ToString();
    }
}