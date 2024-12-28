using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private float time = 30.0f;
    public Text timeText;
    public void Update()
    {
        if (time <= 0)
        {
            Debug.Log("Game Over "+ ((int)time).ToString());
            time=0;
        }
        else
        {
            time -= Time.deltaTime;
        }
        timeText.text = "Time: " + ((int)time).ToString();
    }
}