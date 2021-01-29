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

        List<string> cardName = new List<string>() { "", "", "", "", ""};

        if (cardCount == 0)
            Debug.Log("Err. No cards.");
        else
        {
            // Turn off cards over cardCount.
            for (int i = cardCount + 1; i < 5; i++)
                TurnOffCard(i.ToString());

            // Turn on cards up to cardCount
            for (int i = 0; i < cardCount; i++)
            {
                cardName[i] = AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[i].invItem.label;
                TurnOnCard(cardName[i], i + 1);
            }

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
