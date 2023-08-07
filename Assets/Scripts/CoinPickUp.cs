using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip CoinClip;
    [SerializeField] int pointsForCoinPickup = 100;
    [SerializeField] bool WasColected = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !WasColected)
        {
            WasColected = true;
            AudioSource.PlayClipAtPoint(CoinClip, Camera.main.transform.position);
            FindObjectOfType<GameSession>().processScores(pointsForCoinPickup);
            Destroy(gameObject);
        }    
    }
}
