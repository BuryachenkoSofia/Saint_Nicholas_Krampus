using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class MenuControl : MonoBehaviour
{
    public GameObject levelMenu;
    public void Awake()
    {
        if(!PlayerPrefs.HasKey("difficultyLevel"))
        {
            PlayerPrefs.SetInt("difficultyLevel", 0);
        }
    }
    public void StartGame(int difficultyLevel)
    {
        if(difficultyLevel == 0){
            SceneManager.LoadScene(2);
        } 
        PlayerPrefs.SetInt("difficultyLevel", difficultyLevel); /*0-6*/
        SceneManager.LoadScene(1);
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