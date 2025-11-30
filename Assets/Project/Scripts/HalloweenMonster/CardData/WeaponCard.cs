using UnityEngine;
using System.Collections.Generic;

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
