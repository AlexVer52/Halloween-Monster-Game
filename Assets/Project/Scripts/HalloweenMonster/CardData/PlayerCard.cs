using UnityEngine;
using System.Collections.Generic;

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