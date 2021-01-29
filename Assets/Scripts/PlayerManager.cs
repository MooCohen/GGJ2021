using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class PlayerManager : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer playerFight;
    
    void Start(){
        player.sprite = setPlayerDressUpSprite();
        playerFight.sprite = setPlayerFightSprite();
    } 


    private Sprite setPlayerDressUpSprite() {
        switch (AC.GlobalVariables.GetVariable(0).GetValue()) {
            case "Bald":
                return Resources.Load<Sprite>("Art/Characters/Man_one");
                break;
            case "Bangs":
                return Resources.Load<Sprite>("Art/Characters/Girl_two");
                break;
            case "Curls":
                return Resources.Load<Sprite>("Art/Characters/Girl_three_full_revised");
                break;
            case "Pink":
                return Resources.Load<Sprite>("Art/Characters/Girl_one");
                break;
            default:
                return Resources.Load<Sprite>("Art/Characters/Man_one");
                break;
        }
    }

    private Sprite setPlayerFightSprite() {
        switch (AC.GlobalVariables.GetVariable(0).GetValue()) {
            case "Bald":
                return Resources.Load<Sprite>("Art/Characters/Man_one_fight");
                break;
            case "Bangs":
                return Resources.Load<Sprite>("Art/Characters/Girl_two_fight");
                break;
            case "Curls":
                return Resources.Load<Sprite>("Art/Characters/Girl_three_fight_revised");
                break;
            case "Pink":
                return Resources.Load<Sprite>("Art/Characters/Girl_one_fight");
                break;
            default:
                return Resources.Load<Sprite>("Art/Characters/Man_one_fight");
                break;
        }
    }
}
