using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class Fight : MonoBehaviour
{
    public GameObject player;
    public GameObject playerFight;
    public GameObject opponent;
    public GameObject opponentFight;

    public ParticleSystem hearts; 
    public ParticleSystem stars;
    public Char opponent_npc;
    public MoveInfo.moveType opponentType;

	public MoveInfo.matchUp lastMatchUp;

    void Start(){
        //reset confidence for player and opponent
        AC.GlobalVariables.GetVariable(2).IntegerValue = 0;
        AC.GlobalVariables.GetVariable(4).IntegerValue = 0;
    }
    
    void ShowFight(){
        player.SetActive(false);
        playerFight.SetActive(true);
        opponent.SetActive(false);
        opponentFight.SetActive(true);
    }

    void HideFight(){
        player.SetActive(true);
        playerFight.SetActive(false);
        opponent.SetActive(false);
        opponentFight.SetActive(true);
    }

    private void OnEnable () {
        EventManager.OnVariableChange += VariableChange;
        EventManager.OnMenuElementClick += ElementClick;
    }

    private void OnDisable () {
        EventManager.OnVariableChange -= VariableChange;
        EventManager.OnMenuElementClick -= ElementClick;
    }

    //Checks if Self Confidence has changed to update display
    private void VariableChange (GVar variable) {
        MenuSlider healthSlider = (MenuSlider) PlayerMenus.GetElementWithName ("Self Confidence Bar", "Bar");
        MenuSlider opponentSlider = (MenuSlider) PlayerMenus.GetElementWithName ("Opponent Bar", "Bar");

        switch (variable.id) {
            case 1:
                Debug.Log("Max Self Confidence Increased");
                healthSlider.maxValue = (float)variable.IntegerValue;
                break;
            case 2:
                Debug.Log("Current Self Confidence Increased");
                healthSlider.amount = (float)variable.IntegerValue / (float)AC.GlobalVariables.GetVariable(1).IntegerValue * 10;
                break;
            case 4:
                Debug.Log("Opponent Confidence Increased");
                opponentSlider.amount = (float)variable.IntegerValue / (float)AC.GlobalVariables.GetVariable(1).IntegerValue * 10;
                break;
            default:
                break;
        }
    }

    //Checks if a move was selected
    private void ElementClick (AC.Menu _menu, MenuElement _element, int _slot, int _buttonPressed)
    {
        if (_menu.title == "Fight")
        {
            //Handles fight menu display
            AC.PlayerMenus.GetElementWithName (_menu.title, _element.title).IsVisible = false;
            AC.GlobalVariables.GetVariable(3).IntegerValue++;
            _menu.TurnOff(false);
            DetermineDamage(CleanMoveName(_element));
            DetermineOpponentDamage();

            //If used all  moves, determine a winner
            if (AC.GlobalVariables.GetVariable(3).IntegerValue == 4){
                CalculateWinner();
            } else {
                //Before using all moves.
                if (AC.GlobalVariables.GetVariable(2).IntegerValue >= 10){
                    StartCoroutine("Win");
                }

                //Player lost all self confidence
                else if (AC.GlobalVariables.GetVariable(2).IntegerValue == 0){
                    StartCoroutine("Lost");
                }

                //Opponent has max self confidence
                else if (AC.GlobalVariables.GetVariable(4).IntegerValue == 10){
                    StartCoroutine("Lost");
                }
                else {
                    StartCoroutine("DialogueCutScene");
                    _menu.TurnOn(false);
                }
            }
        }
    }

	private string CleanMoveName(MenuElement element)
	{
		string name = (element as AC.MenuButton).label;
		if (name[0] == '+')
			return name.Substring(2);
		else
			return name;
	}

    private IEnumerator DialogueCutScene() {
        KickStarter.stateHandler.EnforceCutsceneMode = true;
        List<string> advantagePhrases = new List<string> {
            "Hot damn!",
            "You're looking great!",
            "Wow I love that look on you!",
            "Daaaaaaamnn, nice outfit!",
            "You're making me sweat over here!"
        };

        List<string> disadvantagePhrases = new List<string> {
            "I feel great in this! Oh, I didn't even see you there for a moment.",
            "This is my favorite outfit, you don't have a chance.",
            "Eh, I think you can do better.",
            "I'm not really impressed yet.",
            "Hm, this will be easy"
        };

        List<string> neutralPhrases = new List<string> {
            "Eh, not bad. But could be better.",
            "This all you got?",
            "Nice moves, but not nice enough.",
            "I mean, it doesn't wow me but I don't hate it."
        };
        string advantagePhrase = advantagePhrases [Random.Range(0, advantagePhrases.Count)];
        string disadvantagePhrase = disadvantagePhrases [Random.Range(0, disadvantagePhrases.Count)];
        string neutralPhrase = neutralPhrases [Random.Range(0, neutralPhrases.Count)];

		//TODO import lines, opponent says something when their move is stronger, or something else when move is weaker
		if (lastMatchUp == MoveInfo.matchUp.ADV)
		{
			hearts.Play();
			stars.Play();
			KickStarter.dialog.StartDialog(opponent_npc, advantagePhrase);
		}
		else if (lastMatchUp == MoveInfo.matchUp.NEUTRAL)
		{
			hearts.Play();
			KickStarter.dialog.StartDialog(opponent_npc, neutralPhrase);
		}
		else if (lastMatchUp == MoveInfo.matchUp.DISADV)
		{
			KickStarter.dialog.StartDialog(opponent_npc, disadvantagePhrase);
		}

        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        hearts.Stop();
        stars.Stop();
        KickStarter.stateHandler.EnforceCutsceneMode = false;
    }

    void CalculateWinner(){
        //Checks if player is more confident than opponent
        //Right now, a tie is considered a loss.
        if(AC.GlobalVariables.GetVariable(2).IntegerValue > AC.GlobalVariables.GetVariable(4).IntegerValue){
            StartCoroutine("Win");
        } else {
            StartCoroutine("Lost");
        }
    }


    private IEnumerator Win()
    {
        KickStarter.stateHandler.EnforceCutsceneMode = true;
        AC.KickStarter.mainCamera.Shake(0.5f, 0.5f, CameraShakeEffect.Translate);

        List<string> wins = new List<string> {
            "Wow! You really taught me a thing or two!",
            "Beginner's luck!",
            "Gosh you look good.",
            "You did great out there!",
            "Damn you can really work it."
        };
        string winner = wins [Random.Range(0, wins.Count)];
        
        //Give random item
        List<int> carried = new List<int>();

        for (int i = 0; i < 12; i++) {
            bool carrying = AC.KickStarter.runtimeInventory.IsCarryingItem(i);
            if (carrying){
                carried.Add(i);
            }
        }

        int itemCarried = carried [Random.Range(0, carried.Count)];
        
        InvItem carriedInv = AC.KickStarter.runtimeInventory.GetItem(itemCarried);
        if (carried.Count > 2) {
            AC.KickStarter.runtimeInventory.Remove(itemCarried);
        }

        List<string> giveItems = new List<string> {
            "What? You'll let me have " + carriedInv.altLabel + "? Thank you! I love it!",
            "You... you sure? I can really have your " + carriedInv.altLabel + "? Awesome!",
            "Ohh I love your " + carriedInv.altLabel + ". What? I can have it for next time? Thank you!!",
        };
        string giveItem = giveItems [Random.Range(0, giveItems.Count)];

        //Adds +5 max self confidence
        AC.GlobalVariables.GetVariable(1).IntegerValue += 5;
        AC.GlobalVariables.GetVariable(7).IntegerValue += 1;


        hearts.Play();
        stars.Play();
        KickStarter.dialog.StartDialog(opponent_npc, winner);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.dialog.StartDialog(opponent_npc, "You're looking more confident! (+5 Self Confidence)");
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }
        if (carried.Count > 2) {
            KickStarter.dialog.StartDialog(opponent_npc, giveItem);
            while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
            {
                yield return new WaitForFixedUpdate();
            }
        }

        hearts.Stop();
        stars.Stop();
        KickStarter.stateHandler.EnforceCutsceneMode = false;
        GoToMap();
    }

    private IEnumerator Lost()
    {
        KickStarter.stateHandler.EnforceCutsceneMode = true;

        //Give random item
        List<int> notCarried = new List<int>();

        for (int i = 0; i < 12; i++) {
            bool carrying = AC.KickStarter.runtimeInventory.IsCarryingItem(i);
            if (!carrying){
                notCarried.Add(i);
            }
        }
        Debug.Log("Not holding: " + notCarried);
        Debug.Log("Not holding count: " + notCarried.Count);

        List<string> byes = new List<string> {
            "Find me here if you ever want a rematch.",
            "See you around.",
            "If you ever want a re-match, I'll be around.",
            "Don't be a stranger.",
            "Let me know how you like the new clothes! Bye for now."
        };
        string bye = byes [Random.Range(0, byes.Count)];

        List<string> losts = new List<string> {
            "You look good, but I look better.",
            "Nice try, better luck next time.",
            "Practice makes perfect, see you again sometime?",
            "Sorry kid, you're up against some tough competition.",
            "Nice try, but I know how good I look in this.",
            "Sorry kid, you're up against some tough competition",
            "Win or lose? Ha it was never a question!",
            "Of course, I'm the best"
        };
        string lost = losts [Random.Range(0, losts.Count)];

        int newItem = notCarried [Random.Range(0, notCarried.Count)];
        
        InvItem newInv = AC.KickStarter.inventoryManager.GetItem(newItem);

        AC.KickStarter.runtimeInventory.Add(newItem);

        List<string> haveThis = new List<string> {
            "Here, maybe this " + newInv.altLabel + " will help ya next time.",
            "Losing isn't all that bad.  Take this " + newInv.altLabel + ".",
            "Just because you lost doesn't mean you can't try again.  Here, have my old " + newInv.altLabel + ".",
            "Want my old " + newInv.altLabel + "? Maybe some of my luck will rub off on ya.",
            "You put up a good fight.  I want you to have this " + newInv.altLabel + ".",
        };
        string have = haveThis [Random.Range(0, haveThis.Count)];

        KickStarter.dialog.StartDialog(opponent_npc, lost);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.dialog.StartDialog(opponent_npc, have);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.dialog.StartDialog(opponent_npc, bye);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.stateHandler.EnforceCutsceneMode = false;
        GoToMap();
    }

    void GoToMap(){
        //Turn off Self Confidence Bar
        PlayerMenus.GetMenuWithName ("Self Confidence Bar").TurnOff(false);
        PlayerMenus.GetMenuWithName ("Opponent Bar").TurnOff(false);
        //Go to Map Scene
        AC.KickStarter.sceneChanger.ChangeScene (1, false);
    }

    //Goth > Cowboy > Cute
    void DetermineDamage(string moveName){
		MoveInfo.Move move = MoveInfo.moves[moveName];
		lastMatchUp = MoveInfo.GetMatchUp(move.type, opponentType);

		if (lastMatchUp == MoveInfo.matchUp.ADV)
		{
			AC.GlobalVariables.GetVariable(2).IntegerValue += 4;
		}
		else if (lastMatchUp == MoveInfo.matchUp.DISADV)
		{
			AC.GlobalVariables.GetVariable(2).IntegerValue += 1;
		}
		else if (lastMatchUp == MoveInfo.matchUp.NEUTRAL)
			AC.GlobalVariables.GetVariable(2).IntegerValue += 2;
    }

    void DetermineOpponentDamage(){
		//TODO "Opponent used _______" visible on a menu or dialog, have opponent actually pick moves/etc.
		//Determine enemy damage by player lvl. This could be better for balance.

        string level = AC.GlobalVariables.GetVariable(7).GetValue();
        switch(level) {
            case "0":
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 3;
                break;
            case "1":
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 4;
                break;
            case "2":
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 4;
                break;
            case "3":
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 4;
                break;
            case "4":
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 5;
                break;
            case "5":
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 5;
                break;
            default:
        		AC.GlobalVariables.GetVariable(4).IntegerValue += 5;
                break;
        }
    }


    private IEnumerator Hello()
    {

        List<string> helloPhrases = new List<string> {
                "Looking for a fight? Too bad! It's nothing but fashion here.",
                "Fashionably late, I see",
                "Oh, you got what it takes to compete? Great!",
                "Ohh a fresh face, let's see what you got",
                "Hi! I'm excited to see what you wear.",
                "Good luck going up against me! I only wear the finest."
        };

        KickStarter.stateHandler.EnforceCutsceneMode = true;

        string hello = helloPhrases [Random.Range(0, helloPhrases.Count)];

        KickStarter.dialog.StartDialog(opponent_npc, hello);
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        PlayerMenus.GetMenuWithName ("Dress Up").TurnOn();
        AC.KickStarter.mainCamera.FadeOut(0.5f);
        player.SetActive(true);
        opponent.SetActive(false);
        AC.KickStarter.mainCamera.FadeIn(0.5f);

        KickStarter.stateHandler.EnforceCutsceneMode = false;
    }
}
