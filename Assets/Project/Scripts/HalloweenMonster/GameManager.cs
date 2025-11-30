using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public AttackManager attackManager;
    public ResolutionManager resolutionManager;
    public PlayerCardView playerCardPrefab;
    public PlayerCard playerCardData;
    public GameObject attackSelectionPanel;
    public List<Player> players = new List<Player>();
    public List<Player> turnQueue = new List<Player>();
    public List<Monster> monstreOnField = new List<Monster>();
    public TextMeshProUGUI phaseText;
    public GameObject winningScreen;
    public TextMeshProUGUI winningText;
    public bool gameEnded = false;
    public int maxHP = 0;
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

        int count = Mathf.Max(1, SceneDatabase.playerCount);
        for (int i = 0; i < count; i++)
        {
            Player player = new Player(playerCardData);
            int nombreDeJoueurs = players.Count;
            player.playerName = "Player " + (nombreDeJoueurs + 1);
            player.playerIndex = nombreDeJoueurs;
            players.Add(player);
        }

        Debug.Log("Number of players: " + players);
        currentPhase = GamePhase.Discussion;
        Debug.Log("Game Started. Current Phase: " + currentPhase);
    }

    public void StartAttack()
    {
        if (players.Count == 0)
        {
            Debug.LogWarning("No players in the game. Cannot start attack phase.");
            return;
        }
        currentPhase = NextPhase(currentPhase);
        //Debug.Log("Phase changed to: " + currentPhase + ", button was clicked.");
        // Additional logic for handling phase change can be added here
    }

    public GamePhase NextPhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.Discussion:
                StartNextPlayerAttackPhase(0);
                return GamePhase.Attack;
            case GamePhase.Attack:
                resolutionManager.ResolveAttacks();
                return GamePhase.Resolution;
            case GamePhase.Resolution:
                return GamePhase.Discussion;
            default: return GamePhase.Discussion;
        }
    }

    public void AffichagePhaseTMP()
    {
        phaseText.text = "Phase: " + currentPhase.ToString();
    }

    public void StartNextPlayerAttackPhase(int playerIndex)
    {
        Player currentPlayer = players[playerIndex];
        Debug.Log("Current player: " + currentPlayer.playerName + " / stored index = " + currentPlayer.playerIndex);
        attackManager.StartAttackPhase(currentPlayer);
    }


    void Update()
    {
        AffichagePhaseTMP();
    }
}
