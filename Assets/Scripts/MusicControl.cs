using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameObject BGMusic;
    private bool music;
    void Update()
    {
        music = PlayerPrefs.GetInt("music") == 1 ? true : false;
        if (music)
        {
            BGMusic.SetActive(true);
        }
        else
        {
            BGMusic.SetActive(false);
        }
    }
}
