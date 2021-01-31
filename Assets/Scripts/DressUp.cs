using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class DressUp : MonoBehaviour
{
    public GameObject Head;
    public GameObject Torso;
    public GameObject Legs;
    public GameObject Feet;
    public GameObject FightHead;
    public GameObject FightTorso;
    public GameObject FightLegs;
    public GameObject FightFeet;

    void PutItOn()
    {
        InvItem clothing = AC.KickStarter.runtimeInventory.LastSelectedItem;
        string playerName = AC.GlobalVariables.GetVariable(0).GetValue();
        //Use those two to determine which version of the item becomes visible (or is instantiated).
        PutOn(clothing, playerName);

        //If another of that type is visible, hide it + return the card

        //After That
        //Opponent Clothing Generated
        //Manage the stats of the clothes that are on, compare w/ the opponent
        //List the moves from the cards as what you can put on
        //Then dress up again and do it again until there's a winner
        //Character selection
    }

    void PutOn(InvItem article, string playerName){
        switch (playerName) {
            case "Bald":
                BaldGetsDressed(article.label.Trim());
                break;
            case "Bangs":
                BangsGetsDressed(article.label.Trim());
                break;
            case "Curly":
                CurlyGetsDressed(article.label.Trim());
                break;
            case "Pink":
                PinkGetsDressed(article.label.Trim());
                break;
        }
    }

    void BaldGetsDressed(string articleName){
        //Cowboy
        if (articleName.Equals(ID.COWBOY_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_HAT_FIGHT);
            
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.COWBOY_HAT;
        }
        if (articleName.Equals(ID.COWBOY_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.COWBOY_FEET;
        
        }
        if (articleName.Equals(ID.COWBOY_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.COWBOY_TORSO;
        
        }
        if (articleName.Equals(ID.COWBOY_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.COWBOY_LEGS;
        
        }

        //Cute
        if (articleName.Equals(ID.CUTE_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.CUTE_HAT;
        
        }
        if (articleName.Equals(ID.CUTE_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.CUTE_FEET;

        }
        if (articleName.Equals(ID.CUTE_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.CUTE_TORSO;
        
        }
        if (articleName.Equals(ID.CUTE_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.CUTE_LEGS;

        }

        //Goth
        if (articleName.Equals(ID.GOTH_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.GOTH_HAT;
        
        }
        if (articleName.Equals(ID.GOTH_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.GOTH_FEET;

        }
        if (articleName.Equals(ID.GOTH_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.GOTH_TORSO;
        
        }
        if (articleName.Equals(ID.GOTH_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.GOTH_LEGS;

        }
    }


    void CurlyGetsDressed(string articleName){
        //Cowboy
        if (articleName.Equals(ID.COWBOY_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.COWBOY_HAT;
        }
        if (articleName.Equals(ID.COWBOY_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.COWBOY_FEET;
        }
        if (articleName.Equals(ID.COWBOY_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.COWBOY_TORSO;
        }
        if (articleName.Equals(ID.COWBOY_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.COWBOY_LEGS;
        }

        //Cute
        if (articleName.Equals(ID.CUTE_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.CUTE_HAT;
        }
        if (articleName.Equals(ID.CUTE_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.CUTE_FEET;
        }
        if (articleName.Equals(ID.CUTE_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.CUTE_TORSO;
        }
        if (articleName.Equals(ID.CUTE_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.CUTE_LEGS;
        }

        //Goth
        if (articleName.Equals(ID.GOTH_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.GOTH_HAT;
        }
        if (articleName.Equals(ID.GOTH_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.GOTH_FEET;
        }
        if (articleName.Equals(ID.GOTH_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.GOTH_TORSO;
        }
        if (articleName.Equals(ID.GOTH_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.GOTH_LEGS;
        }
    }


    void PinkGetsDressed(string articleName){
        //Cowboy
        if (articleName.Equals(ID.COWBOY_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.COWBOY_HAT;
        }
        if (articleName.Equals(ID.COWBOY_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.COWBOY_FEET;
        }
        if (articleName.Equals(ID.COWBOY_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.COWBOY_TORSO;
        }
        if (articleName.Equals(ID.COWBOY_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.COWBOY_LEGS;
        }

        //Cute
        if (articleName.Equals(ID.CUTE_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.CUTE_HAT;
        }
        if (articleName.Equals(ID.CUTE_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.CUTE_FEET;
        }
        if (articleName.Equals(ID.CUTE_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.CUTE_TORSO;
        }
        if (articleName.Equals(ID.CUTE_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.CUTE_LEGS;
        }

        //Goth
        if (articleName.Equals(ID.GOTH_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.GOTH_HAT;
        }
        if (articleName.Equals(ID.GOTH_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.GOTH_FEET;
        }
        if (articleName.Equals(ID.GOTH_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.GOTH_TORSO;
        }
        if (articleName.Equals(ID.GOTH_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.GOTH_LEGS;
        }
    }


    void BangsGetsDressed(string articleName){
        //Cowboy
        if (articleName.Equals(ID.COWBOY_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.COWBOY_HAT;
        }
        if (articleName.Equals(ID.COWBOY_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.COWBOY_FEET;
        }
        if (articleName.Equals(ID.COWBOY_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.COWBOY_TORSO;
        }
        if (articleName.Equals(ID.COWBOY_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.COWBOY_LEGS;
        }

        //Cute
        if (articleName.Equals(ID.CUTE_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.CUTE_HAT;
        }
        if (articleName.Equals(ID.CUTE_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.CUTE_FEET;
        }
        if (articleName.Equals(ID.CUTE_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.CUTE_TORSO;
        }
        if (articleName.Equals(ID.CUTE_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.CUTE_LEGS;
        }

        //Goth
        if (articleName.Equals(ID.GOTH_HAT)){
            Head.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_HAT);
            FightHead.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_HAT_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "4") as AC.MenuButton).label = DESC.GOTH_HAT;
        }
        if (articleName.Equals(ID.GOTH_FEET)){
            Feet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_FEET);
            FightFeet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_FEET_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "3") as AC.MenuButton).label = DESC.GOTH_FEET;
        }
        if (articleName.Equals(ID.GOTH_TORSO)){
            Torso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_TORSO);
            FightTorso.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_TORSO_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "2") as AC.MenuButton).label = DESC.GOTH_TORSO;
        }
        if (articleName.Equals(ID.GOTH_LEGS)){
            Legs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_LEGS);
            FightLegs.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_LEGS_FIGHT);
            (AC.PlayerMenus.GetElementWithName ("Fight", "1") as AC.MenuButton).label = DESC.GOTH_LEGS;
        }
    }
}
