using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private bool instantKill = true;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float hitCooldown = 1f;
    [SerializeField] private AudioClip trapSound;

    private float lastHitTime = -1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time >= lastHitTime + hitCooldown)
            {
                HitPlayer(collision);
                lastHitTime = Time.time;
            }
        }
    }

    private void HitPlayer(Collider2D playerCollider)
    {
        if (trapSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(trapSound);
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RespawnPlayer();
        }
    }
}