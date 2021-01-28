using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class CardDisplay : MonoBehaviour
{
    void Start()
    {
        //Check how many cards total, if only have 3 or 2 or 1 just show those cards
        //The cards are intertwine with the Adventure Creator Inventory system, but to display them w generated text+img they have to be menu elements so its a weird combo.
        int cardCount = AC.KickStarter.runtimeInventory.GetNumberOfItemsCarried();
        string card1name;
        string card2name;
        string card3name;
        string card4name;

        switch(cardCount) {
            case 0:
                Debug.Log("Err. No cards.");
                break;
            case 1:
                TurnOffCard("2");
                TurnOffCard("3");
                TurnOffCard("4");
                card1name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[0].invItem.label;
                TurnOnCard(card1name, 1);
                break;
            case 2:
                TurnOffCard("3");
                TurnOffCard("4");
                card1name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[0].invItem.label;
                TurnOnCard(card1name, 1);
                card2name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[1].invItem.label;
                TurnOnCard(card2name, 2);
                break;
            case 3:
                TurnOffCard("4");
                card1name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[0].invItem.label;
                TurnOnCard(card1name, 1);
                card2name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[1].invItem.label;
                TurnOnCard(card2name, 2);
                card3name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[2].invItem.label;
                TurnOnCard(card3name, 3);
                break;
            default:
                card1name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[0].invItem.label;
                TurnOnCard(card1name, 1);
                card2name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[1].invItem.label;
                TurnOnCard(card2name, 2);
                card3name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[2].invItem.label;
                TurnOnCard(card3name, 3);
                card4name =  AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[3].invItem.label;
                TurnOnCard(card4name, 4);
                break;
        }
        //Check order of inventory, first card show the matching img/title/desc
        //second show second
        //etc
        
    }

    //TODO this could be refactored
    void TurnOnCard(string name, int cardNumber) {
            if (name.Trim().Equals(TITLE.COWBOY_FEET)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.COWBOY_FEET;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.COWBOY_FEET;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_FEET);
            }

            if (name.Trim().Equals(TITLE.COWBOY_LEGS)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.COWBOY_LEGS;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.COWBOY_LEGS;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_LEGS);
            }
            
            if (name.Trim().Equals(TITLE.COWBOY_TORSO)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.COWBOY_TORSO;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.COWBOY_TORSO;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_TORSO);
            }

            if (name.Trim().Equals(TITLE.COWBOY_HAT)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.COWBOY_HAT;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.COWBOY_HAT;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_HAT);
            }

            if (name.Trim().Equals(TITLE.GOTH_FEET)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.GOTH_FEET;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.GOTH_FEET;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_FEET);
            }

            if (name.Trim().Equals(TITLE.GOTH_LEGS)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.GOTH_LEGS;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.GOTH_LEGS;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_LEGS);
            }

            if (name.Trim().Equals(TITLE.GOTH_TORSO)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.GOTH_TORSO;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.GOTH_TORSO;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_TORSO);
            }

            if (name.Trim().Equals(TITLE.GOTH_HAT)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.GOTH_HAT;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.GOTH_HAT;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_HAT);
            }

            if (name.Trim().Equals(TITLE.CUTE_FEET)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.CUTE_FEET;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.CUTE_FEET;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_FEET);
            }

            if (name.Trim().Equals(TITLE.CUTE_LEGS)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.CUTE_LEGS;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.CUTE_LEGS;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_LEGS);
            }

            if (name.Trim().Equals(TITLE.CUTE_TORSO)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.CUTE_TORSO;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.CUTE_TORSO;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_TORSO);
            }

            if (name.Trim().Equals(TITLE.CUTE_HAT)){
                MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
                labelElement.label = TITLE.CUTE_HAT;
                MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
                labelElement1.label = DESC.CUTE_HAT;
                MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
                graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_HAT);
            }
    }

    void TurnOffCard(string cardNumber){
        AC.PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title").IsVisible = false;
        AC.PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc").IsVisible = false;
        AC.PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img").IsVisible = false;
    }
}
