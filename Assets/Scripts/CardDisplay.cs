using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class CardDisplay : MonoBehaviour
{
    public int clicks = 1;
    private int cardCount;
    private List<string> cardName = new List<string>();

    void Start()
    {
        //Check how many cards total, if only have 3 or 2 or 1 just show those cards
        //The cards are intertwine with the Adventure Creator Inventory system, but to display them w generated text+img they have to be menu elements so its a weird combo.
        int cardCount = AC.KickStarter.runtimeInventory.GetNumberOfItemsCarried();


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
                cardName.Add(AC.KickStarter.runtimeInventory.playerInvCollection.invInstances[i].invItem.label);
                if (i < 4){
                    TurnOnCard(cardName[i], i + 1);
                }
            }
        }
    }

    private void OnEnable () {
        EventManager.OnMenuElementClick += ElementClick;
    }

    private void OnDisable () {
        EventManager.OnMenuElementClick -= ElementClick;
    }


    //Checks if a move was selected
    private void ElementClick (AC.Menu _menu, MenuElement _element, int _slot, int _buttonPressed)
    {
        if (_menu.title == "Dress Up")
        {
            if (_element.title == "ShiftRight"){
                clicks += 1;

                TurnOnCard(cardName[clicks], 1);
                TurnOnCard(cardName[clicks + 1], 2);
                TurnOnCard(cardName[clicks + 2], 3);
                TurnOnCard(cardName[clicks + 3], 4);
            }

            if (_element.title == "ShiftLeft"){
                clicks -= 1;

                TurnOnCard(cardName[clicks], 1);
                TurnOnCard(cardName[clicks + 1], 2);
                TurnOnCard(cardName[clicks + 2], 3);
                TurnOnCard(cardName[clicks + 3], 4);
            }
        }
    }

    public void TurnOnCard(string name, int cardNumber) {
        if (name.Trim().Equals(ID.COWBOY_FEET)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_FEET;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_FEET;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_FEET);
        }

        if (name.Trim().Equals(ID.COWBOY_LEGS)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_LEGS;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_LEGS;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_LEGS);
        }
        
        if (name.Trim().Equals(ID.COWBOY_TORSO)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_TORSO;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_TORSO;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_TORSO);
        }

        if (name.Trim().Equals(ID.COWBOY_HAT)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_HAT;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_HAT;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_HAT);
        }

        if (name.Trim().Equals(ID.GOTH_FEET)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_FEET;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_FEET;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_FEET);
        }

        if (name.Trim().Equals(ID.GOTH_LEGS)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_LEGS;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_LEGS;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_LEGS);
        }

        if (name.Trim().Equals(ID.GOTH_TORSO)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_TORSO;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_TORSO;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_TORSO);
        }

        if (name.Trim().Equals(ID.GOTH_HAT)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_HAT;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_HAT;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_HAT);
        }

        if (name.Trim().Equals(ID.CUTE_FEET)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_FEET;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_FEET;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_FEET);
        }

        if (name.Trim().Equals(ID.CUTE_LEGS)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_LEGS;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_LEGS;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_LEGS);
        }

        if (name.Trim().Equals(ID.CUTE_TORSO)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_TORSO;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_TORSO;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Dress Up", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_TORSO);
        }

        if (name.Trim().Equals(ID.CUTE_HAT)){
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
