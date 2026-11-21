using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    //Observer event shared by all collectibles.
    public static event Action OnCollected;

    private bool isCollected = false;

    //Handle player entering the trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ignore other objects and repeated collisions.
        if (!other.CompareTag("Player") || isCollected)
            return;

        isCollected = true;

        //Notify subscribers of collection.
        OnCollected?.Invoke();

        //Remove collected crystal.
        Destroy(gameObject);
    }
}