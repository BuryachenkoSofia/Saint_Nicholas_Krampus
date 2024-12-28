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
    void Start()
    {
        for (int i = 0; i < houses.Length; i++){
            houses[i].house = GameObject.Find("House " + (i + 1).ToString());
            houses[i].houseGift = Random.Range(2, 6);
            houses[i].houseText = houses[i].house.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
            houses[i].houseText.text = houses[i].houseGift.ToString();

        }
    }
}