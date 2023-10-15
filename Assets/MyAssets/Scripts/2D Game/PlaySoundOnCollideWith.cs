using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollideWith : MonoBehaviour
{
    public string tagToCompare = "Player";
    public bool onTrigger = true;
    public bool onCollision = true;
    public bool shouldDestroy = true;
    public AudioClip mAudioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTrigger)
        {
            if (collision)
            {
                if (collision.tag == tagToCompare)
                {
                    PlaySound();
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onCollision)
        {
            if (collision.collider)
            {
                if (collision.collider.tag == tagToCompare)
                {
                    PlaySound();
                }
            }
        }
    }

    void PlaySound()
    {
        GameObject audioSourceObject = new GameObject();
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(mAudioClip);
        Destroy(audioSourceObject, mAudioClip.length);
        if(shouldDestroy) Destroy(gameObject);
    }
}
