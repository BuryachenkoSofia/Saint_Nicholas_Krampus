using UnityEngine;
using UnityEngine.UI;

public struct House
{
    public GameObject house;
    public Text houseText;
    public int houseGift;
}

public class HousesControl : MonoBehaviour
{
    public House[] houses = new House[5];
    void Start()
    {
        for (int i = 0; i < houses.Length; i++){
            houses[i].house = GameObject.Find("House " + (i + 1).ToString());
            //houses[i].houseText = houses[i].house.GetComponentInChildren<Text>();
            houses[i].houseGift = Random.Range(1, 6);
            Debug.Log(houses[i].houseGift + " gifts; " + houses[i].house.name);
        }
    }
}