using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuControl : MonoBehaviour
{
    public GameObject levelMenu, pauseMenu;
    public Text soundButtonText, musicButtonText;
    public void Awake()
    {
        if (!PlayerPrefs.HasKey("difficultyLevel"))
        {
            PlayerPrefs.SetInt("difficultyLevel", 0);
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
        }
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                soundButtonText.text = "Sound: On";
            }
            else
            {
                soundButtonText.text = "Sound: Off";
            }
            if (PlayerPrefs.GetInt("music") == 1)
            {
                musicButtonText.text = "Music: On";
            }
            else
            {
                musicButtonText.text = "Music: Off";
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                PauseButton();
            }
        }
    }
    public void StartGame(int difficultyLevel)
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("difficultyLevel", difficultyLevel);
        if (difficultyLevel == 0)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void StartButton()
    {
        levelMenu.SetActive(true);
    }
    public void ExitLevelMenu()
    {
        levelMenu.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void PauseButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    public void Sound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            soundButtonText.text = "Sound: Off";
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
            soundButtonText.text = "Sound: On";
        }
    }
    public void Music()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            PlayerPrefs.SetInt("music", 0);
            musicButtonText.text = "Music: Off";
        }
        else
        {
            PlayerPrefs.SetInt("music", 1);
            musicButtonText.text = "Music: On";
        }
    }
    public void Reset(){
        PlayerPrefs.DeleteAll();
        RestartGame();
    }
}