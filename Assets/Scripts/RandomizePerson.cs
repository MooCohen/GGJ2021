using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePerson : MonoBehaviour
{
    public SpriteRenderer Head;
    public SpriteRenderer Torso;
    public SpriteRenderer Legs;
    public SpriteRenderer Feet;
    public SpriteRenderer opponent;
    public AudioSource music;
    public AudioClip cowboySong;
    public AudioClip gothSong;
    public AudioClip cuteSong;

    public SpriteRenderer Head_Fight;
    public SpriteRenderer Torso_Fight;
    public SpriteRenderer Legs_Fight;
    public SpriteRenderer Feet_Fight;
    public SpriteRenderer opponent_Fight;

    void Start()
    {
        //0 Bald, 1 Pink, 2 Curly, 3 Bangs. Set it as an int but get it as a string cause idk its a "PopUp" which is an enum.
        int randomPerson = Random.Range(0, 4);
        AC.GlobalVariables.GetVariable(5).IntegerValue = randomPerson;
        Debug.Log(AC.GlobalVariables.GetVariable(5).GetValue());
        SetCharacter();
    }

    void SetCharacter()
    {
        //0 Bald, 1 Pink, 2 Curly, 3 Bangs
        string person = AC.GlobalVariables.GetVariable(5).GetValue();

        switch (person) {
            case "Bald":
                opponent.sprite = Resources.Load<Sprite>(CHARACTER.BALD_FULL);
                if(opponent_Fight){
                    opponent_Fight.sprite = Resources.Load<Sprite>(CHARACTER.BALD_FIGHT);
                }
                break;
            case "Pink":
                opponent.sprite = Resources.Load<Sprite>(CHARACTER.PINK_FULL);
                if(opponent_Fight){
                    opponent_Fight.sprite = Resources.Load<Sprite>(CHARACTER.PINK_FIGHT);
                }
                break;
            case "Curly":
                opponent.sprite = Resources.Load<Sprite>(CHARACTER.CURLY_FULL);
                if(opponent_Fight){
                    opponent_Fight.sprite = Resources.Load<Sprite>(CHARACTER.CURLY_FIGHT);
                }
                break;
            case "Bangs":
                opponent.sprite = Resources.Load<Sprite>(CHARACTER.BANGS_FULL);
                if(opponent_Fight){
                    opponent_Fight.sprite = Resources.Load<Sprite>(CHARACTER.BANGS_FIGHT);
                }
                break;
        }
        SetOutfit(person);
    }

    void SetOutfit(string person) {
        //0 Goth, 1 Cowboy, 2 Cute
        int randomGenre = Random.Range(0, 3);
        AC.GlobalVariables.GetVariable(6).IntegerValue = randomGenre;

        // SetMusic(randomGenre);

        if (person == "Bald"){
            SetBaldOutfit(randomGenre);
        }
        if (person == "Pink"){
            SetPinkOutfit(randomGenre);
        }
        if (person == "Bangs"){
            SetBangsOutfit(randomGenre);
        }
        if (person == "Curly"){
            SetCurlyOutfit(randomGenre);
        }
    }

    void SetMusic(int genre){
        switch (genre) {
            case 0:
                music.clip = gothSong;
                music.Play();
                break;
            case 1:
                music.clip = cowboySong;
                music.Play();
                break;
            case 2:
                music.clip = cuteSong;
                music.Play();
                break;
        }
    }

    void SetBaldOutfit(int genre) {
        switch (genre) {
            case 0:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.GOTH_LEGS_FIGHT);
                }
                break;
            case 1:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.COWBOY_LEGS_FIGHT);
                }
                break;
            case 2:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BALD.CUTE_LEGS_FIGHT);
                }
                break;
        }
    }

    void SetBangsOutfit(int genre) {
        switch (genre) {
            case 0:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.GOTH_LEGS_FIGHT);
                }
                break;
            case 1:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.COWBOY_LEGS_FIGHT);
                }
                break;
            case 2:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + BANGS.CUTE_LEGS_FIGHT);
                }
                break;
        }
    }

    void SetCurlyOutfit(int genre) {
        switch (genre) {
            case 0:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.GOTH_LEGS_FIGHT);
                }
                break;
            case 1:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.COWBOY_LEGS_FIGHT);
                }
                break;
            case 2:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_LEGS);

                if(opponent_Fight){
                    Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_HAT_FIGHT);
                    Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_TORSO_FIGHT);
                    Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_FEET_FIGHT);
                    Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + CURLY.CUTE_LEGS_FIGHT);
                }
                break;
        }
    }

    void SetPinkOutfit(int genre) {
        switch (genre) {
            case 0:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_LEGS);

                Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_HAT_FIGHT);
                Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_TORSO_FIGHT);
                Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_FEET_FIGHT);
                Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.GOTH_LEGS_FIGHT);
                break;
            case 1:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_LEGS);

                Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_HAT_FIGHT);
                Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_TORSO_FIGHT);
                Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_FEET_FIGHT);
                Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.COWBOY_LEGS_FIGHT);
                break;
            case 2:
                Head.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_HAT);
                Torso.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_TORSO);
                Feet.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_FEET);
                Legs.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_LEGS);

                Head_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_HAT_FIGHT);
                Torso_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_TORSO_FIGHT);
                Feet_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_FEET_FIGHT);
                Legs_Fight.sprite = Resources.Load<Sprite>("Art/Outfits/" + PINK.CUTE_LEGS_FIGHT);
                break;
        }
    }
}
