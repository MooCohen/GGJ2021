using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class PlayerManager : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer playerFight;

    void Start(){
        player.sprite = setDressUpSprite();
        if (playerFight){
            playerFight.sprite = setFightSprite();
        }

        //Start of match, reset to 0 used moves
        AC.GlobalVariables.GetVariable(3).IntegerValue = 0;
    } 


    private Sprite setFightSprite() {
        switch (AC.GlobalVariables.GetVariable(0).GetValue()) {
            case "Bald":
                return Resources.Load<Sprite>(CHARACTER.BALD_FIGHT);
                break;
            case "Bangs":
                return Resources.Load<Sprite>(CHARACTER.BANGS_FIGHT);
                break;
            case "Curly":
                return Resources.Load<Sprite>(CHARACTER.CURLY_FIGHT);
                break;
            case "Pink":
                return Resources.Load<Sprite>(CHARACTER.PINK_FIGHT);
                break;
            default:
                return Resources.Load<Sprite>(CHARACTER.BALD_FIGHT);
                break;
        }
    }

    private Sprite setDressUpSprite() {
        switch (AC.GlobalVariables.GetVariable(0).GetValue()) {
            case "Bald":
                return Resources.Load<Sprite>(CHARACTER.BALD_FULL);
                break;
            case "Bangs":
                return Resources.Load<Sprite>(CHARACTER.BANGS_FULL);
                break;
            case "Curly":
                return Resources.Load<Sprite>(CHARACTER.CURLY_FULL);
                break;
            case "Pink":
                return Resources.Load<Sprite>(CHARACTER.PINK_FULL);
                break;
            default:
                return Resources.Load<Sprite>(CHARACTER.BALD_FULL);
                break;
        }
    }
}
