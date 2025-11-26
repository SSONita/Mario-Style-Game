using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private int pointValue = 10;
    [SerializeField] private AudioClip collectSound;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            CollectFruit();
        }
    }

    private void CollectFruit()
    {
        collected = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddFruitScore(pointValue);
        }

        if (collectSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(collectSound);
        }

        gameObject.SetActive(false);
    }

    public int GetPointValue()
    {
        return pointValue;
    }
}