using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public void RestartGame()
    {
        // Load the Character Selection scene
        SceneManager.LoadScene("Start");
    }

}
