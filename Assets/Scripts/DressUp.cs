using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class DressUp : MonoBehaviour
{
    void PutItOn()
    {
        Debug.Log("I am holding: " + AC.KickStarter.runtimeInventory.LastSelectedItem.label);
        //NEXT UP
        //Use the label above
        //Get The Player's Character Sprite
        //Use those two to determine which version of the item becomes visible (or is instantiated). 
        //If another of that type is visible, hide it + return the card

        //After That
        //Outfit Selected Button "Ready!"
        //Opponent Clothing Generated
        //Manage the stats of the clothes that are on, compare w/ the opponent
        //List the moves from the cards as what you can put on
        //Then dress up again and do it again until there's a winner
        //Character selection
    }
}
