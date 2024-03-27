using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;
    public float volume = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the objects you want
        if (collision.gameObject.CompareTag("Roof"))
        {
            // Play the collision sound effect with adjusted volume
            AudioSource.PlayClipAtPoint(collisionSound, new Vector3(-13.0799999f, 0f, -10f), volume);
        }
    }
}
