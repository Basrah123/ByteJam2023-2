using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] bool armor;
    [SerializeField] bool health;
    [SerializeField] int amount;
    [SerializeField] AudioClip sfx;
    AudioSource myAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(armor)
            {
                other.GetComponent<Health>().UpdateArmor(amount);
            }
            if(health)
            {
                other.GetComponent<Health>().ApplyHealing(amount);
            }

            myAudio = other.GetComponent<AudioSource>();
            myAudio.clip = sfx;
            myAudio.Play();

            Destroy(gameObject);
        }
    }
}
