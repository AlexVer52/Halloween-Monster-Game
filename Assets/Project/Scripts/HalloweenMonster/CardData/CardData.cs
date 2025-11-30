using UnityEngine;

public enum CardType
{
    Monster,
    Player,
    Weapon
}

public class CardData : ScriptableObject
{
    public int id;
    public string cardName;
    public Sprite cardImage;
    public CardType cardType;
}


