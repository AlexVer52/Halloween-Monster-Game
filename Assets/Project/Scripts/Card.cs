using UnityEngine;
[System.Serializable]
public enum CardType
{
    Monster,
    Player,
    Weapon,
    Special
}

public abstract class Card : ScriptableObject  // <- make it abstract so you never create "Card" directly
{
    public string cardName;
    public CardType cardType;
    public string description;
}

[CreateAssetMenu(fileName = "NewMonsterCard", menuName = "Cards/Monster")]
public class MonsterCard : Card
{
    public int hp;
    public int rewardVP;
    public string rewardWeapon;

    private void OnEnable()
    {
        cardType = CardType.Monster;
    }
}

[CreateAssetMenu(fileName = "NewWeaponCard", menuName = "Cards/Weapon")]
public class WeaponCard : Card
{
    public int attackPower;

    private void OnEnable()
    {
        cardType = CardType.Weapon;
    }
}

[CreateAssetMenu(fileName = "NewPlayerCard", menuName = "Cards/Player")]
public class PlayerCard : Card
{
    public int hp;

    private void OnEnable()
    {
        cardType = CardType.Player;
    }
}
