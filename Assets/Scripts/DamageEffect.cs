using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] Image damageImage;
    [SerializeField] float displayTime;
    void Start()
    {
        // Make sure the image is initially disabled
        damageImage.enabled = false;
    }

    public void Play()
    {
        // Enable the image
        damageImage.enabled = true;
        GetComponent<AudioSource>().Play();
        // Use Invoke to disable the image after a certain time
        Invoke("HideDamageEffect", displayTime);
    }

    void HideDamageEffect()
    {
        // Disable the image
        damageImage.enabled = false;
    }
}
