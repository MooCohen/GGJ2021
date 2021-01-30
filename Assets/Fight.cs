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
    public ParticleSystem opponentHearts; 
    public ParticleSystem opponentStars; 
    public Char opponent_npc;
    public string opponentType;

    
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

        switch (variable.id) {
            case 1:
                Debug.Log("Max Self Confidence Increased");
                healthSlider.maxValue = (float)variable.IntegerValue;
                break;
            case 2:
                Debug.Log("Current Self Confidence Increased");
                healthSlider.amount = (float)variable.IntegerValue / (float)AC.GlobalVariables.GetVariable(1).IntegerValue * 10;
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
            _menu.TurnOff();

            DetermineDamage(_element.title);
            DetermineOpponentDamage();
            
            //If used all  moves, determine a winner
            if (AC.GlobalVariables.GetVariable(3).IntegerValue == 4){
                CalculateWinner();
            } else {
                StartCoroutine("DialogueCutScene");
                _menu.TurnOn();
            }
        }
    }

    private IEnumerator DialogueCutScene() {
        KickStarter.stateHandler.EnforceCutsceneMode = true;

        //TODO turn on particle effect behind who ever did better that round
        hearts.Play(); // opponentHearts.Play();
        stars.Play(); // opponentStars.Play();

        //TODO import lines, opponent says something when their move is stronger, or something else when move is weaker
        KickStarter.dialog.StartDialog(opponent_npc, "hot damn");
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        hearts.Stop();
        stars.Stop();
        KickStarter.stateHandler.EnforceCutsceneMode = false;
    }

    void CheckForWin() {
        //Player maxed out their self confidence
        if (AC.GlobalVariables.GetVariable(2).IntegerValue == 10){
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

        //Used all available moves
        else if (AC.GlobalVariables.GetVariable(3).IntegerValue == 4){
            CalculateWinner();
        }
    }

    void CalculateWinner(){
        //Checks if player is more confident than opponent
        //Right now, a tie is considered a loss.
        if(AC.GlobalVariables.GetVariable(2).IntegerValue > AC.GlobalVariables.GetVariable(4).IntegerValue){
            Debug.Log("You Win!");
            StartCoroutine("Win");
        } else {
            Debug.Log("You Lost!");
            StartCoroutine("Lost");
            //TODO give an article of clothing
        }
    }

    private IEnumerator Win()
    {
        KickStarter.stateHandler.EnforceCutsceneMode = true;

        //Adds +5 max self confidence
        AC.GlobalVariables.GetVariable(1).IntegerValue += 5;
        //TODO Some dialog or menu line about your self confidence growing

        hearts.Play();
        stars.Play();
        KickStarter.dialog.StartDialog(opponent_npc, "Wow! You really taught me a thing or two!");
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.dialog.StartDialog(opponent_npc, "Take this, I think it'd look good on you.");
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }
        //TODO gain a random card. Show a line saying what you got.

        hearts.Stop();
        stars.Stop();
        KickStarter.stateHandler.EnforceCutsceneMode = false;
        GoToMap();
    }

    private IEnumerator Lost()
    {
        KickStarter.stateHandler.EnforceCutsceneMode = true;

        KickStarter.dialog.StartDialog(opponent_npc, "Nice try, but I know how good I look in this.");
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.dialog.StartDialog(opponent_npc, "Find me here if you ever want a rematch.");
        while (KickStarter.dialog.CharacterIsSpeaking(opponent_npc))
        {
            yield return new WaitForFixedUpdate();
        }

        KickStarter.stateHandler.EnforceCutsceneMode = false;
        GoToMap();
    }

    void GoToMap(){
        //Turn off Self Confidence Bar
        PlayerMenus.GetMenuWithName ("Self Confidence Bar").TurnOff();
        //Go to Map Scene
        AC.KickStarter.sceneChanger.ChangeScene (1, false);
    }

    //Goth > Cowboy > Cute
    void DetermineDamage(string moveName){
        //opponentType = "Goth" "Cowboy" "Cute"

        //TODO check moveName against CardInfo DESC's for the type to determine effectiveness

        //Adds 1 to play self confidence
        AC.GlobalVariables.GetVariable(2).IntegerValue++;
    }

    void DetermineOpponentDamage(){
        //Opponent used _______ visible on a menu or dialog
        //TODO Determine enemy damage.  Enemy max health is same as player

        //Adds 1 to opponent self confidence
        AC.GlobalVariables.GetVariable(4).IntegerValue++;
    }
}
