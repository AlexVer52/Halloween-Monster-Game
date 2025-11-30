using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    public Player currentPlayer; // Player stats
    public List<Player> players = new List<Player>();
    public List<AttackAction> attackQueue = new List<AttackAction>();
    public List<Monster> monsterOnField = new List<Monster>();
    public int selectedMonster;
    public Dropdown weaponSelectionDropdown;
    public Weapon selectedWeapon;
    public AttackAction currentAttackAction;
    public GameObject attackSelectionPanel;
    public GameObject battleField;
    public void StartAttackPhase(Player player)
    {
        monsterOnField = FindObjectOfType<DeckManager>().monstersInGame;
        this.currentPlayer = player;
        Debug.Log("Index de joueur actuel:" + currentPlayer.playerIndex);
        //Debug.Log("Monsters on field for Attack Phase:" + monsterOnField.Count);
        FillDropdown();
        attackSelectionPanel.SetActive(true);
        // Floutter le background
    }

    public void ChoiceMonster1()
    {
        selectedMonster = 0;
        Debug.Log("Selected Monster: " + monsterOnField[selectedMonster].monsterCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void ChoiceMonster2()
    {
        selectedMonster = 1;
        Debug.Log("Selected Monster: " + monsterOnField[selectedMonster].monsterCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void ChoiceMonster3()
    {
        selectedMonster = 2;
        Debug.Log("Selected Monster: " + monsterOnField[selectedMonster].monsterCardData.cardName);
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
        Debug.Log("Index: " + index);
        if (index < 0 || index >= currentPlayer.stuff.Count)
            return;

        // si stuff est une List<WeaponCard>
        selectedWeapon = currentPlayer.stuff[index];
        Debug.Log("Arme choisie : " + currentPlayer.stuff[index].weaponCardData.cardName);
        currentAttackAction = new AttackAction(currentPlayer, selectedMonster, selectedWeapon);
    }

    public void ConfirmAttackButton()
    {
        Debug.Log("Confirming attack by " + currentAttackAction.attacker.playerName + " index " + currentPlayer.playerIndex +
            " on " + monsterOnField[currentAttackAction.defenderSlotIndex].monsterCardData.cardName +
            " using " + currentAttackAction.weaponUsed.weaponCardData.cardName);
        attackQueue.Add(currentAttackAction);
        attackSelectionPanel.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        Debug.Log("Nombre de joueurs: " + gameManager.players.Count);
        if (currentPlayer.playerIndex < gameManager.players.Count - 1)
        {
            gameManager.StartNextPlayerAttackPhase(currentPlayer.playerIndex + 1);
            return;
        }
        else
        {
            Debug.Log("All players have completed their Attack Phase. Total attacks queued: " + attackQueue.Count);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
