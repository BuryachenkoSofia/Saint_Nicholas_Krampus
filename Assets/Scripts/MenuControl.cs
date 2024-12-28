using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    public GameObject levelMenu;
    public void Awake()
    {
        if (!PlayerPrefs.HasKey("difficultyLevel"))
        {
            PlayerPrefs.SetInt("difficultyLevel", 0);
        }
    }
    public void StartGame(int difficultyLevel)
    {
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
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}