using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] Image healthDamageImage;
    [SerializeField] Image armorDamageImage;
    [SerializeField] AudioClip hpDamageSFX;
    [SerializeField] AudioClip armorDamageSFX;
    [SerializeField] float displayTime;
    void Start()
    {
        // Make sure the image is initially disabled
        healthDamageImage.enabled = false;
        armorDamageImage.enabled = false;
    }

    public void HpDamage()
    {
        // Enable the image
        healthDamageImage.enabled = true;
        GetComponent<AudioSource>().clip = hpDamageSFX;
        GetComponent<AudioSource>().Play();
        // Use Invoke to disable the image after a certain time
        Invoke("HideDamageEffect", displayTime);
    }
    public void ArmorDamage()
    {
        armorDamageImage.enabled = true;
        GetComponent<AudioSource>().clip = armorDamageSFX;
        GetComponent<AudioSource>().Play();
        Invoke("HideDamageEffect", displayTime);
    }
    void HideDamageEffect()
    {
        // Disable the image
        healthDamageImage.enabled = false;
        armorDamageImage.enabled = false;
    }
}
