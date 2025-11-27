using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    // Name of this character prefab (set in Inspector)
    public string characterName;

    void OnMouseDown()
    {
        // Save the chosen character globally
        GameSelection.chosenCharacter = characterName;

        // Debug log to confirm click
        Debug.Log("Character selected: " + characterName);

        // Navigate to LevelSelection scene
        SceneManager.LoadScene("LevelSelection");
    }
}
