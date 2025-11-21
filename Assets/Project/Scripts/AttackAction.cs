using UnityEngine;

public class AttackAction
{
    public Player attacker;
    public Monster defender;
    public Weapon weaponUsed;
    public AttackAction(Player attacker, Monster defender, Weapon weaponUsed)
    {
        this.attacker = attacker;
        this.defender = defender;
        this.weaponUsed = weaponUsed;
    }
}
