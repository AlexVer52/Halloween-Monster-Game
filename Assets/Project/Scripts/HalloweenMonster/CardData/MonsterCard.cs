using System.Collections.Generic;
using UnityEngine;

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