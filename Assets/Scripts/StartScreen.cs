using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the Character Selection scene
        SceneManager.LoadScene("CharecterSelection");
    }

}

