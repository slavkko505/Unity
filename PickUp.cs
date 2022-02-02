using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] AudioClip CoinPickUpSFX;
    [SerializeField] float addToScore = 33f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(CoinPickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore(addToScore);
    }
}
