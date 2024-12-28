using TMPro;
using UnityEngine;

public struct House
{
    public GameObject house;
    public TMP_Text houseText;
    public int houseGift;
}

public class HousesControl : MonoBehaviour
{
    public House[] houses = new House[7];
    private int n=2,m=5;
    void Start()
    {
        switch (PlayerPrefs.GetInt("difficultyLevel"))
        {
            case 0:
                n = 1;
                m = 3;
                break;
            case 1:
                n = 1;
                m = 3;
                break;
            case 2:
                n = 2;
                m = 5;
                break;
            case 3: 
                n = 4;
                m = 7;
                break;
            case 4:
                n = 4;
                m = 7;
                break;
            case 5:
                n = 5;
                m = 8;
                break;
        }
        for (int i = 0; i < houses.Length; i++){
            houses[i].house = GameObject.Find("House " + (i + 1).ToString());
            houses[i].houseGift = Random.Range(n, m+1);
            houses[i].houseText = houses[i].house.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
            houses[i].houseText.text = houses[i].houseGift.ToString();
        }
    }
}