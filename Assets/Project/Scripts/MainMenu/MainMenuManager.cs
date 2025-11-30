using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int currentPlayerCount;
    public TextMeshProUGUI numberOfPlayer;
    public void StartHalloweenMonster()
    {
        SceneDatabase.playerCount = currentPlayerCount;

        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.HallowennMonster, SceneDatabase.Scenes.HalloweenMonster)
            .Unload(SceneDatabase.Slots.Menu)
            .WithOverlay()
            .Perform();
    }

    public void AddPlayer()
    {
        currentPlayerCount++;
        numberOfPlayer.text = currentPlayerCount.ToString();
        Debug.Log("Player added");
    }

    public void RemovePlayer()
    {
        currentPlayerCount--;
        numberOfPlayer.text = currentPlayerCount.ToString();
        Debug.Log("Player remove");
    }
}

