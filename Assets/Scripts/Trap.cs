using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float hitCooldown = 1f;
    [SerializeField] private AudioClip trapSound;

    private float lastHitTime = -1f;

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player") && Time.time >= lastHitTime + hitCooldown)
    //     {
    //         if (trapSound != null && AudioManager.Instance != null)
    //         {
    //             AudioManager.Instance.PlaySFX(trapSound);
    //         }

    //         GameManager.Instance.RespawnPlayer();
    //         lastHitTime = Time.time;
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Trap triggered!");
        GameManager.Instance.RespawnPlayer();
    }
}
}
