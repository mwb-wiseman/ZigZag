using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public ScoreController scores;
    public GameObject collectableEffect;

    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Collectable")
        {
            // Randomly select sound effect and play sound
            /*
            float n = Random.Range(0f, 1f);
            if(n >= 0.5)
                audioManager.PlaySound(audioManager.collectable1);
            else
            */
                audioManager.PlaySound(audioManager.collectable2);

            // Update score and destroy object
            scores.UpdateCurrentScore();
            GameObject g = Instantiate(collectableEffect, transform.position, Quaternion.identity);
            Destroy(c.gameObject);
            Destroy(g, 3);
        }
    }

}
