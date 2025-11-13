//using UnityEngine;
//using TMPro;
//using System.Collections;
//
//public class GameManager : MonoBehaviour
//{
//    public enum GamePhase
//    {
//        Discussion,
//        Swap,
//        Attack,
//        Resolution
//    }
//    public TextMeshProUGUI phaseText;
//    public GamePhase currentPhase;
//    public float phaseDuration = 5f;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        StartGame();
//    }
//
//    void StartGame()
//    {
//        currentPhase = GamePhase.Discussion;
//        Debug.Log("Game Started. Current Phase: " + currentPhase);
//        StartCoroutine(AdvancePhases());
//    }
//
//    IEnumerator AdvancePhases()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(phaseDuration);
//
//            currentPhase = NextPhase(currentPhase);
//        }
//    }
//    GamePhase NextPhase(GamePhase phase)
//    {
//        switch (phase)
//        {
//            case GamePhase.Discussion: return GamePhase.Swap;
//            case GamePhase.Swap: return GamePhase.Attack;
//            case GamePhase.Attack: return GamePhase.Resolution;
//            case GamePhase.Resolution: return GamePhase.Discussion;
//            default: return GamePhase.Discussion;
//        }
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        //phaseText.text = "";
//        phaseText.text = $"Phase: {currentPhase}";
//        //phaseText.ForceMeshUpdate();
//    }
//}



using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum GamePhase
    {
        Discussion,
        Swap,
        Attack,
        Resolution
    }

    public TextMeshProUGUI phaseText;

    public GamePhase currentPhase = GamePhase.Discussion;

    public float phaseDuration = 30f;       // 30 seconds per phase
    public float totalGameDuration = 90f;  // 6 minutes = 360 seconds

    private float elapsedTime = 0f;

    void Start()
    {
        StartCoroutine(AdvancePhases());
    }

    IEnumerator AdvancePhases()
    {
        while (elapsedTime < totalGameDuration)
        {
            UpdatePhaseDisplay();
            Debug.Log("Phase: " + currentPhase);

            yield return new WaitForSeconds(phaseDuration);
            elapsedTime += phaseDuration;

            currentPhase = NextPhase(currentPhase);
        }

        Debug.Log("Game Ended");
        phaseText.text = "Game Over";
    }

    GamePhase NextPhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.Discussion: return GamePhase.Swap;
            case GamePhase.Swap: return GamePhase.Attack;
            case GamePhase.Attack: return GamePhase.Resolution;
            case GamePhase.Resolution: return GamePhase.Discussion;
            default: return GamePhase.Discussion;
        }
    }
    void UpdatePhaseDisplay()
    {
        phaseText.text = $"Phase: {currentPhase}";
        Canvas.ForceUpdateCanvases();
        phaseText.ForceMeshUpdate();
    }
}
