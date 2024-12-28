using UnityEngine;

public class GiftGenerator : MonoBehaviour
{
    public GameObject giftPrefab;
    public Sprite[] images = new Sprite[6];
    public void Spawn(int n){
        if(n < 1) return;

        int giftsNow = GameObject.FindGameObjectsWithTag("Gift").Length;
        if(giftsNow > 10) return;

        for (int i = 0; i < n; i++)
        {
            giftPrefab.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, 6)];
            Instantiate(giftPrefab, new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(16.0f, 24.0f)), Quaternion.identity);
        }
    }
}