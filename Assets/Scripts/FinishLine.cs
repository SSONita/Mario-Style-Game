using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject resultsPanel;

    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !finished)
        {
            finished = true;
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.FinishLevel();
        }

        if (resultsPanel != null)
        {
            resultsPanel.SetActive(true);
        }
    }
}