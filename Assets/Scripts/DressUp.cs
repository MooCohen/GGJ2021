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
    public Sprite[] bald_outfits;
    public Sprite[] bangs_outfits;
    public Sprite[] curly_outfits;
    public Sprite[] pink_outfits;

    void PutItOn()
    {
        InvItem clothing = AC.KickStarter.runtimeInventory.LastSelectedItem;
        string playerName = AC.GlobalVariables.GetVariable(0).GetValue();
        //Use those two to determine which version of the item becomes visible (or is instantiated).

        switch (playerName) {
            case "Bald":
                PutOn(clothing, bald_outfits);
                break;
            case "Bangs":
                PutOn(clothing, bald_outfits);
                break;
            case "Curly":
                PutOn(clothing, bald_outfits);
                break;
            case "Pink":
                PutOn(clothing, bald_outfits);
                break;
        }

        //If another of that type is visible, hide it + return the card

        //After That
        //Outfit Selected Button "Ready!"
        //Opponent Clothing Generated
        //Manage the stats of the clothes that are on, compare w/ the opponent
        //List the moves from the cards as what you can put on
        //Then dress up again and do it again until there's a winner
        //Character selection
    }

    void PutOn(InvItem article, Sprite[] wardrobe){
        switch (article.binID) {
            case 0:
                WhatBodyPart("Cowboy", article, wardrobe);
                break;
            case 1:
            //goth
            case 2:
            //cute
                break;
        }
    }

    void WhatBodyPart(string category, InvItem article, Sprite[] wardrobe) {
        foreach (Sprite outfit in wardrobe) {
            Debug.Log("outfit.name: " + outfit.name);
            Debug.Log("article.label: " + article.label);

            if (article.label.Contains(outfit.name.ToUpper())){
                Debug.Log("MATCH!!!");
            }
        }
    }
    
}
