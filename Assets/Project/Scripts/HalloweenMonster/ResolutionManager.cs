using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    public AttackManager attackManager;
    public GameManager gameManager;
    public DeckManager deckManager;
    public List<AttackAction> resolvedAttacks = new List<AttackAction>();
    public List<Monster> monsterOnField = new List<Monster>();
    public GameObject announcementPanel;
    public TextMeshProUGUI announcementText;
    public int monsterKilled = 0;

    public List<AttackAction> attackThatKilled = new List<AttackAction>();

    public void ResolveAttacks()
    {
        resolvedAttacks = attackManager.attackQueue;
        Debug.Log("Resolving " + resolvedAttacks.Count + " attacks.");

        // Sort the attacks by attacker HP descending
        resolvedAttacks.Sort((a, b) => b.attacker.playerCardData.hp.CompareTo(a.attacker.playerCardData.hp));

        foreach (AttackAction attack in resolvedAttacks)
        {
            monsterOnField = FindObjectOfType<DeckManager>().monstersInGame;
            Debug.Log("Monstre dans la liste: " + monsterOnField[0].monsterCardData.cardName + ", " + monsterOnField[1].monsterCardData.cardName + ", " + monsterOnField[2].monsterCardData.cardName);
            ExecuteAttack(attack);
            Debug.Log("Resolving attack by " + attack.attacker.playerCardData.cardName +
                " on " + monsterOnField[attack.defenderSlotIndex].monsterCardData.cardName +
                " using " + attack.weaponUsed.weaponCardData.cardName);
        }

        if (attackThatKilled.Count > 0)
        {
            StartCoroutine(ShowKillAnnouncements());
        }

        Debug.Log("All attacks resolved: " + resolvedAttacks.Count);
        attackManager.attackQueue.Clear();
    }

    public string ExecuteAttack(AttackAction attack)
    {
        int damage = attack.weaponUsed.weaponCardData.attackPower;
        Monster defender = monsterOnField[attack.defenderSlotIndex];
        Debug.Log("Before attack, " + defender.monsterCardData.cardName + " has " + defender.currentHp + " HP.");
        defender.currentHp -= damage;
        Debug.Log(attack.attacker.playerCardData.cardName + " attacked " + defender.monsterCardData.cardName + " for " + damage + " damage. Remaining HP: " + defender.currentHp);

        if (defender.currentHp <= 0)
        {
            attack.killedMonsterName = defender.monsterCardData.cardName;

            ////////////
            // La carte du 2eme monstre tué n'est pas retiré si il apparait sur le champs de bataille et meurt dans le même tour!!!
            deckManager.ReplaceDeadMonster(defender);
            ///////////

            CollectRewards(defender, attack.attacker);
            Debug.Log(defender.monsterCardData.cardName + " has been defeated by " + attack.attacker.playerCardData.cardName + "!");
            Debug.Log(attack.attacker.playerCardData.cardName + " now has " + attack.attacker.rewardPoints + " Victory Points and " + attack.attacker.stuff.Count + " items.");
            Debug.Log("Weapons: " + attack.attacker.stuff.ConvertAll(w => w.weaponCardData.cardName).ToArray());
            attackThatKilled.Add(attack);
        }

        return null;
    }

    public void CollectRewards(Monster defeatedMonster, Player attacker)
    {
        MonsterCard monsterCard = defeatedMonster.monsterCardData;
        if (monsterCard.rewardVP > 0)
        {
            attacker.rewardPoints += monsterCard.rewardVP;
            Debug.Log("Player earns " + monsterCard.rewardVP + " Victory Points!");
        }
        if (monsterCard.rewardWeapon != null)
        {
            for (int i = 0; i < monsterCard.rewardWeapon.Count; i++)
            {
                Weapon newWeapon = monsterCard.rewardWeapon[i];
                attacker.stuff.Add(newWeapon);
                Debug.Log("Player earns weapon: " + monsterCard.rewardWeapon[i].weaponCardData.cardName);
            }
        }
    }

    private IEnumerator ShowKillAnnouncements()
    {
        announcementPanel.SetActive(true);
        for (int i = 0; i < attackThatKilled.Count; i++)
        {
            AttackAction attack = attackThatKilled[i];
            // Ce monstre ne sera probablement plus bon, car je ne stocke pas le nom du monstre qui s'est fait tué.
            string defeatedMonster = attack.killedMonsterName;

            announcementText.text = attack.attacker.playerName + " has defeated " + defeatedMonster + "!";

            // Attendre que le joueur appuie sur la barre espace
            bool waiting = true;
            while (waiting)
            {
                if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    waiting = false;
                }
                yield return null; // attendre la frame suivante
            }
        }
        announcementPanel.SetActive(false);
        attackThatKilled.Clear();
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.NextPhase(GameManager.GamePhase.Resolution);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
