using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string levelName; // e.g. "Level01" or "Level02"

    void OnMouseDown()
    {
        GameSelection.chosenLevel = levelName;
        Debug.Log("Level selected: " + levelName);

        // Load the chosen level scene
        SceneManager.LoadScene(levelName);
    }
}