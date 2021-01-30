using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class PlayerManager : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer playerFight;
    
    public SpriteRenderer opponent;
    public SpriteRenderer opponentFight;

    void Start(){
        player.sprite = setDressUpSprite();
        playerFight.sprite = setFightSprite();

        GenerateOpponent();
        //Start of match, reset to 0 used moves
        AC.GlobalVariables.GetVariable(3).IntegerValue = 0;
    } 

    void GenerateOpponent(){
        //TODO this function
        // opponentType = //"Goth" "Cowboy" "Cute"
    }


    private Sprite setDressUpSprite() {
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

    private Sprite setFightSprite() {
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
