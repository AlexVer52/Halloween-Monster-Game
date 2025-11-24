using System.Collections.Generic;
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
    public Sprite artwork;
    public List<WeaponCard> rewardWeaponCards = new List<WeaponCard>();
    public List<Weapon> rewardWeapon = new List<Weapon>();

    private void OnEnable()
    {
        for (int i = 0; i < rewardWeaponCards.Count; i++)
        {
            Weapon weapon = new Weapon(rewardWeaponCards[i]);
            rewardWeapon.Add(weapon);
        }
        cardType = CardType.Monster;
    }
}

[CreateAssetMenu(menuName = "Cards/Player")]
public class PlayerCard : CardData
{
    public string description;
    public int hp;
    public WeaponCard startingWeapon;
    public List<Weapon> stuff = new List<Weapon>();

    private void OnEnable()
    {
        cardType = CardType.Player;
        Weapon weapon = new Weapon(startingWeapon);
        stuff.Add(weapon);
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
