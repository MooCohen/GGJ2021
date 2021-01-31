using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class Trade : MonoBehaviour
{
    public Char opponent_npc;
    private InvItem carriedInv;
    private InvItem offeredInv;

    private List<string> greetings = new List<string> {
        "Hey hot stuff. Looking for a trade?",
        "Afternoon! Wanna swap goods?",
        "Are you new around here? Welcome! Here, you might be into this...",
        "Trying to change up your wardrobe huh? Maybe this will help.",
        "Sup?",
        "Hiiii!! Hey, would you wanna try this on? I think it'll fit!"
    };

    private List<string> goodbyes = new List<string> {
        "See you around",
        "Meet me in the parking lot sometime.",
        "Have fun, hot stuff.",
        "Byebye",
        "Catch ya later.",
        "Can't wait to run into you again."
    };

    void Start()
    {
        List<int> carried = new List<int>();
        List<int> notCarried = new List<int>();

        for (int i = 0; i < 12; i++) {
            bool carrying = AC.KickStarter.runtimeInventory.IsCarryingItem(i);
            if (carrying){
                carried.Add(i);
            } else {
                notCarried.Add(i);
            }
        }

        int itemCarried = carried [Random.Range(0, carried.Count)];
        int itemOffered = notCarried [Random.Range(0, notCarried.Count)];
        
         carriedInv = AC.KickStarter.runtimeInventory.GetItem(itemCarried);
         offeredInv = AC.KickStarter.inventoryManager.GetItem(itemOffered);

        TurnOnCard(carriedInv.label, 1);
        TurnOnCard(offeredInv.label, 2);
    }

    public IEnumerator Greet() {
        KickStarter.stateHandler.EnforceCutsceneMode = true;
        
        string greeting = greetings [Random.Range(0, greetings.Count)];

        KickStarter.dialog.StartDialog(opponent_npc, greeting);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }
        PlayerMenus.GetMenuWithName ("Trade").TurnOn();

        KickStarter.stateHandler.EnforceCutsceneMode = false;
    }

    public IEnumerator Goodbye() {
        KickStarter.stateHandler.EnforceCutsceneMode = true;

        string goodbye = goodbyes [Random.Range(0, goodbyes.Count)];

        KickStarter.dialog.StartDialog(opponent_npc, goodbye);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }
        KickStarter.stateHandler.EnforceCutsceneMode = false;
        PlayerMenus.GetMenuWithName ("To Map").TurnOff();
        AC.KickStarter.mainCamera.FadeOut(0.5f);
        AC.KickStarter.sceneChanger.ChangeScene (1, false);
        AC.KickStarter.mainCamera.FadeIn(0.5f);
    }

    private IEnumerator Yes() {
        KickStarter.stateHandler.EnforceCutsceneMode = true;
        AC.KickStarter.runtimeInventory.Add(offeredInv.id);
        AC.KickStarter.runtimeInventory.Remove(carriedInv.id);


        List<string> trades = new List<string> {
            "Awesome! I'm excited to wear my new " + carriedInv.altLabel + "!",
            "Ohh yeah that " + offeredInv.altLabel + " looks great on you.",
            "Good trade",
            "It's a deal!",
            "Looking sharp.",
            "You're ready to crush the runway!",
            "That " + offeredInv.altLabel + " really shows you off. Enjoy it!",
            "I've held on to that " + offeredInv.altLabel + " for years. Glad to have found a proper new owner." 
        };

        string trade = trades [Random.Range(0, trades.Count)];
        KickStarter.dialog.StartDialog(opponent_npc, trade);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.stateHandler.EnforceCutsceneMode = false;
    }


    private IEnumerator No() {
        KickStarter.stateHandler.EnforceCutsceneMode = true;

        List<string> noTrades = new List<string> {
            "That's ok, it's important to know what you want.",
            "I can respect that.",
            "Aw dang, I really liked your " + carriedInv.altLabel + ".",
            "You sure? Ah well.",
            "Your loss",
            "Hmm. That's ok, I wasn't really ready to say goodbye to my " + offeredInv.altLabel + "."
        };
        string noTrade = noTrades [Random.Range(0, noTrades.Count)];

        KickStarter.dialog.StartDialog(opponent_npc, noTrade);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.stateHandler.EnforceCutsceneMode = false;
    }


    void TurnOnCard(string name, int cardNumber) {
        if (name.Trim().Equals(ID.COWBOY_FEET)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_FEET;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_FEET;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_FEET);

            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Feet Card");
        }

        if (name.Trim().Equals(ID.COWBOY_LEGS)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_LEGS;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_LEGS;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_LEGS);
            
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Legs Card");
        }
        
        if (name.Trim().Equals(ID.COWBOY_TORSO)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_TORSO;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_TORSO;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_TORSO);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Torso Card");
        }

        if (name.Trim().Equals(ID.COWBOY_HAT)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.COWBOY_HAT;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.COWBOY_HAT;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.COWBOY_HAT);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Head Card");
        }

        if (name.Trim().Equals(ID.GOTH_FEET)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_FEET;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_FEET;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_FEET);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Feet Card");
        }

        if (name.Trim().Equals(ID.GOTH_LEGS)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_LEGS;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_LEGS;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_LEGS);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Legs Card");
        }

        if (name.Trim().Equals(ID.GOTH_TORSO)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_TORSO;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_TORSO;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_TORSO);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Torso Card");
        }

        if (name.Trim().Equals(ID.GOTH_HAT)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.GOTH_HAT;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.GOTH_HAT;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.GOTH_HAT);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Head Card");
        }

        if (name.Trim().Equals(ID.CUTE_FEET)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_FEET;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_FEET;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_FEET);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Feet Card");
        }

        if (name.Trim().Equals(ID.CUTE_LEGS)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_LEGS;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_LEGS;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_LEGS);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Legs Card");
        }

        if (name.Trim().Equals(ID.CUTE_TORSO)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_TORSO;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_TORSO;
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_TORSO);
        }

        if (name.Trim().Equals(ID.CUTE_HAT)){
            MenuLabel labelElement = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Title");
            labelElement.label = TITLE.CUTE_HAT;
            MenuLabel labelElement1 = (MenuLabel) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Desc");
            labelElement1.label = DESC.CUTE_HAT;
            MenuGraphic graphicElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " Img");
            graphicElement.graphic.texture = Resources.Load<Texture>("Art/Clothes/" + IMG.CUTE_HAT);
            MenuGraphic bgElement = (MenuGraphic) PlayerMenus.GetElementWithName ("Trade", "Card " + cardNumber + " BG");
            bgElement.graphic.texture = Resources.Load<Texture>("Art/Cards/Head Card");
        }
    }
}
