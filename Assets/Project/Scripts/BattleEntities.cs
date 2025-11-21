using UnityEngine;

[System.Serializable]
public class Player
{
    public PlayerCard playerCardData;
    public System.Collections.Generic.List<Weapon> stuff = new System.Collections.Generic.List<Weapon>();

    public Player(PlayerCard playerCardData)
    {
        this.playerCardData = playerCardData;
        if (playerCardData.stuff != null)
        {
            this.stuff.AddRange(playerCardData.stuff);

        }
    }
}

[System.Serializable]
public class Monster
{
    public MonsterCard monsterCardData;

    public Monster(MonsterCard monsterCardData)
    {
        this.monsterCardData = monsterCardData;
    }
}

public class Weapon
{
    public WeaponCard weaponCardData;

    public Weapon(WeaponCard weaponCardData)
    {
        this.weaponCardData = weaponCardData;
    }
}
