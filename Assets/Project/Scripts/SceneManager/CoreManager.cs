using UnityEngine;

public class CoreManager : MonoBehaviour
{
    void Start()
    {
        // Core Setup for the game
        // Load Everything like Audio Manager, Save System,...
        SceneController.Instance
            .NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu)
            .Perform();
    }

}
