using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum GamePhase
    {
        Discussion,
        Attack,
        Resolution
    }

    public GamePhase currentPhase = GamePhase.Discussion;

    public float phaseDuration = 30f;       // 30 seconds per phase
    public float totalGameDuration = 90f;  // 6 minutes = 360 seconds

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        currentPhase = GamePhase.Discussion;
        Debug.Log("Game Started. Current Phase: " + currentPhase);
        // WWhen every Player is ready or something like that (Ready button)
    }

    GamePhase NextPhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.Discussion: return GamePhase.Attack;
            case GamePhase.Attack: return GamePhase.Resolution;
            case GamePhase.Resolution: return GamePhase.Discussion;
            default: return GamePhase.Discussion;
        }
    }
    void Update()
    {

    }
}
