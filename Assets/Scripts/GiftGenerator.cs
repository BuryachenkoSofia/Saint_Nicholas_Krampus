using UnityEngine;

public class GiftGenerator : MonoBehaviour
{
    public GameObject giftPrefab;
    public Sprite[] images = new Sprite[6];
    private bool first = true;
    public void Spawn(int n)
    {
        if (n < 1) return;
        if (PlayerPrefs.GetInt("difficultyLevel") != 0)
        {
            int giftsNow = GameObject.FindGameObjectsWithTag("Gift").Length;
            if (giftsNow > n * 5) return;

            for (int i = 0; i < n; i++)
            {
                giftPrefab.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, 6)];
                Instantiate(giftPrefab, new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(16.0f, 24.0f)), Quaternion.identity);
            }
        }
        else if (first)
        {
            int giftsNow = GameObject.FindGameObjectsWithTag("Gift").Length;
            if (giftsNow >= 3) return;

            for (int i = -1; i < n - 1; i++)
            {
                giftPrefab.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, 6)];
                Instantiate(giftPrefab, new Vector2(4.0f * i, 23.0f), Quaternion.identity);
            }
        }
        first=false;
    }
}