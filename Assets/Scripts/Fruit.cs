using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Fruit collected!");
            GameManager.Instance.AddFruitScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
