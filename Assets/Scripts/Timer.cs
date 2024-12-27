using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private float time = 0.0f;
    public Text timeText;
    public void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + time.ToString("F2");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}