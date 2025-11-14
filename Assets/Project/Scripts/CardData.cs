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

[CreateAssetMenu(menuName = "Cards/Monster")]
public class MonsterCard : CardData
{
    public string description;
    public int hp;
    public int rewardVP;
    public string rewardWeapon;

    private void OnEnable()
    {
        cardType = CardType.Monster;
    }
}

[CreateAssetMenu(menuName = "Cards/Player")]
public class PlayerCard : CardData
{
    public string description;
    public int hp;
    public string stuff;

    private void OnEnable()
    {
        cardType = CardType.Player;
    }
}

[CreateAssetMenu(menuName = "Cards/Weapon")]
public class WeaponCard : CardData
{
    public string description;
    public int attackPower;

    private void OnEnable()
    {
        cardType = CardType.Weapon;
    }
}
