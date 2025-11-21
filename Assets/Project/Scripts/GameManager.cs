using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public AttackManager attackManager;
    public PlayerCardView playerCardPrefab;
    //public RectTransform playerSlot;
    public PlayerCard playerCardData;
    public GameObject attackSelectionPanel;
    public List<Player> players = new List<Player>();
    public List<Player> turnQueue = new List<Player>();
    public int maxHP = 0;
    public int currentPlayerIndex = 0;
    public enum GamePhase
    {
        Discussion,
        Attack,
        Resolution
    }

    public GamePhase currentPhase = GamePhase.Discussion;

    void Start()
    {
        attackSelectionPanel.SetActive(false);
        StartGame();
    }

    void StartGame()
    {
        currentPhase = GamePhase.Discussion;
        Debug.Log("Game Started. Current Phase: " + currentPhase);
    }

    public void AddPlayer()
    {
        Player player = new Player(playerCardData);
        players.Add(player);
        Debug.Log("Player added: " + player.playerCardData.hp + player.playerCardData.cardName + player.playerCardData.stuff.ToString() + " items.");
    }

    public void StartAttack()
    {
        if (players.Count == 0)
        {
            Debug.LogWarning("No players in the game. Cannot start attack phase.");
            return;
        }
        currentPhase = NextPhase(currentPhase);
        Debug.Log("Phase changed to: " + currentPhase + ", button was clicked.");
        // Additional logic for handling phase change can be added here
    }

    public GamePhase NextPhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.Discussion:
                currentPlayerIndex = 0;
                StartNextPlayerAttackPhase();
                return GamePhase.Attack;
            case GamePhase.Attack:
                Debug.Log("All players have completed their Attack Phase:" + attackManager.attackQueue.Count + " attacks queued.");
                return GamePhase.Resolution;
            case GamePhase.Resolution:
                return GamePhase.Discussion;
            default: return GamePhase.Discussion;
        }
    }

    public void StartNextPlayerAttackPhase()
    {
        if (currentPlayerIndex >= players.Count)
        {
            Debug.Log("All players have completed their Attack Phase.");
            return;
        }
        Player currentPlayer = players[currentPlayerIndex];
        attackManager.StartAttackPhase(currentPlayer);
    }

    void Update()
    {

    }
}
