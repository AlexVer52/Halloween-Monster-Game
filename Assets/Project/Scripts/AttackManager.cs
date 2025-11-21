using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public Player currentPlayer; // Player stats
    public List<Player> players = new List<Player>();
    public List<AttackAction> attackQueue = new List<AttackAction>();
    public List<Monster> monsterOnField = new List<Monster>();
    public Monster selectedMonster;
    public Dropdown weaponSelectionDropdown;
    public Weapon selectedWeapon;
    public AttackAction currentAttackAction;
    public GameObject attackSelectionPanel;
    public GameObject battleField;
    public void StartAttackPhase(Player player)
    {
        attackQueue.Clear();
        monsterOnField.Clear();
        monsterOnField = FindObjectOfType<DeckManager>().monsterOnField.ConvertAll(m => new Monster(m));
        this.currentPlayer = player;
        Debug.Log("Monsters on field for Attack Phase:" + monsterOnField.Count);
        FillDropdown();
        attackSelectionPanel.SetActive(true);
        // Floutter le background
    }

    public void ChoiceMonster1()
    {
        selectedMonster = monsterOnField[0];
        Debug.Log("Selected Monster: " + selectedMonster.monsterCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void ChoiceMonster2()
    {
        selectedMonster = monsterOnField[1];
        Debug.Log("Selected Monster: " + selectedMonster.monsterCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void ChoiceMonster3()
    {
        selectedMonster = monsterOnField[2];
        Debug.Log("Selected Monster: " + selectedMonster.monsterCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void FillDropdown()
    {
        weaponSelectionDropdown.ClearOptions();
        List<string> weaponNames = new List<string>();
        foreach (Weapon weapon in currentPlayer.stuff)
        {
            weaponNames.Add(weapon.weaponCardData.cardName);
        }
        weaponSelectionDropdown.AddOptions(weaponNames);

        // sélection initiale
        if (currentPlayer.stuff.Count > 0)
        {
            weaponSelectionDropdown.value = 0;
            ChoiceWeapon(0); // on force une sélection initiale
        }
    }

    public void ChoiceWeapon(int index)
    {
        if (index < 0 || index >= currentPlayer.stuff.Count)
            return;

        // si stuff est une List<WeaponCard>
        selectedWeapon = currentPlayer.stuff[index];
        Debug.Log("Arme choisie : " + currentPlayer.stuff[index].weaponCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void ConfirmAttackButton()
    {
        Debug.Log("Confirming attack by " + currentAttackAction.attacker.playerCardData.cardName +
            " on " + currentAttackAction.defender.monsterCardData.cardName +
            " using " + currentAttackAction.weaponUsed.weaponCardData.cardName);
        attackQueue.Add(currentAttackAction);
        attackSelectionPanel.SetActive(false);
        Debug.Log("Attack confirmed for " + currentAttackAction.attacker.playerCardData.cardName + ". Processing attacks...");
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.currentPlayerIndex++;
        if (gameManager.currentPlayerIndex < gameManager.players.Count)
        {
            gameManager.StartNextPlayerAttackPhase();
            return;
        }
        else
        {
            Debug.Log("All players have completed their Attack Phase. Total attacks queued: " + attackQueue.Count);
            gameManager.NextPhase(GameManager.GamePhase.Attack);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
