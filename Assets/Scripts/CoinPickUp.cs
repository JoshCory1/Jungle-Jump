using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip CoinClip;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(CoinClip, Camera.main.transform.position);
            Destroy(gameObject);
        }    
    }
}
