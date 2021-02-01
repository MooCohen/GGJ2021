using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInfo : MonoBehaviour
{
	public enum moveType
	{
		GOTH,
		COWBOY,
		CUTE,
		NEUTRAL
	};

	public enum matchUp
	{
		ADV,
		DISADV,
		NEUTRAL
	}

	public struct Move
	{
		public moveType type;
		public string name;

		public Move(moveType type, string name)
		{
			this.type = type;
			this.name = name;
		}
	}

	public static Dictionary<string, Move> moves = new Dictionary<string, Move>()
	{
		{ "Contra Dance", new Move(moveType.COWBOY, "Contra Dance") },
		{ "Hot Dang", new Move(moveType.COWBOY, "Hot Dang") },
		{ "Yeehaw", new Move(moveType.COWBOY, "Yeehaw") },
		{ "Howdy", new Move(moveType.COWBOY, "Howdy") },
		{ "Stomp", new Move(moveType.GOTH, "Stomp") },
		{ "Sad Music", new Move(moveType.GOTH, "Sad Music") },
		{ "Sigh", new Move(moveType.GOTH, "Sigh") },
		{ "Hair Flip", new Move(moveType.GOTH, "Hair Flip") },
		{ "Awww", new Move(moveType.CUTE, "Awww") },
		{ "Strut", new Move(moveType.CUTE, "Strut") },
		{ "Giggle", new Move(moveType.CUTE, "Giggle") },
		{ "Sneeze", new Move(moveType.CUTE, "Sneeze") },
		{ "Dance", new Move(moveType.NEUTRAL, "Dance") },
		{ "Stretch", new Move(moveType.NEUTRAL, "Stretch") },
		{ "Wiggle", new Move(moveType.NEUTRAL, "Wiggle") },
		{ "Wink", new Move(moveType.NEUTRAL, "Wink") },
	};

	public static matchUp GetMatchUp(moveType attack, moveType defense)
	{
		if (attack == defense) return matchUp.NEUTRAL;
		if (attack == moveType.NEUTRAL) return matchUp.NEUTRAL;
		if (attack == moveType.COWBOY && defense == moveType.GOTH) return matchUp.ADV;
		if (attack == moveType.GOTH && defense == moveType.CUTE) return matchUp.ADV;
		if (attack == moveType.CUTE && defense == moveType.COWBOY) return matchUp.ADV;

		if (attack == moveType.COWBOY && defense == moveType.CUTE) return matchUp.DISADV;
		if (attack == moveType.GOTH && defense == moveType.COWBOY) return matchUp.DISADV;
		if (attack == moveType.CUTE && defense == moveType.GOTH) return matchUp.DISADV;

		return matchUp.NEUTRAL;
	}
}
