using UnityEngine;

[System.Serializable]
public class Player
{
    public PlayerCard playerCardData;
    public string playerName;
    public System.Collections.Generic.List<Weapon> stuff = new System.Collections.Generic.List<Weapon>();
    public int rewardPoints = 0;
    public int playerIndex;

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
    public int currentHp;

    public Monster(MonsterCard monsterCardData)
    {
        this.monsterCardData = monsterCardData;
        this.currentHp = monsterCardData.hp;
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
