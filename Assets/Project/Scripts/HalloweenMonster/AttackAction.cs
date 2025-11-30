using UnityEngine;

public class AttackAction
{
    public Player attacker;
    public int defenderSlotIndex;
    public string killedMonsterName;
    public Weapon weaponUsed;
    public DeckManager deckManager;
    public AttackAction(Player attacker, int defenderSlotIndex, Weapon weaponUsed)
    {
        this.attacker = attacker;
        this.defenderSlotIndex = defenderSlotIndex;
        this.weaponUsed = weaponUsed;
    }
}
