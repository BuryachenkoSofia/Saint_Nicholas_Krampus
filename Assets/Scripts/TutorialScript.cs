using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private Player player;
    public GameObject tpMove, tpTeleport, tpGift,  tpHouse, tpTimeAndMass;
    public int stage = 0;
    void Start()
    {
        player = this.GetComponent<Player>();
        AllTpSetActive(false);
    }
    void Update()
    {
        if(PlayerPrefs.GetInt("difficultyLevel") == 0 && stage != 5)
        {
            if(stage == 0)
            {
                tpMove.SetActive(true);
            }

            if(player.isMove && stage == 0){
                AllTpSetActive(false);
                stage=1;
                tpTeleport.SetActive(true);
            }

            if(stage == 1 && player.isSpace){
                AllTpSetActive(false);
                stage=2;
                tpGift.SetActive(true);
            }

            if(player.isGift && stage == 2){
                AllTpSetActive(false);
                stage=3;
                tpHouse.SetActive(true);
            }

            if(player.isHouse && stage == 3){
                AllTpSetActive(false);
                stage=4;
                tpTimeAndMass.SetActive(true);
            }
            if(stage == 4 && player.housesControl.isWin()){
                AllTpSetActive(false);
                stage=5;
            }
        }
    }
    void AllTpSetActive(bool active)
    {
        tpMove.SetActive(active);
        tpTeleport.SetActive(active);
        tpGift.SetActive(active);
        tpTimeAndMass.SetActive(active);
        tpHouse.SetActive(active);
    }
}
