
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class KeyBoard : MonoBehaviour
{
    // public variables 
    public Transform bulletSpawnPoint; 
    public GameObject bulletPrefab; 
    public float bulletSpeed = 50;
    [SerializeField] private float fireRate;
    private float timeSinceLastShot = 0f;
    // variables for relaoding 
    public int currentAmmo, maxClipSize = 24;

    //Audio logic
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip fire;
    private AudioSource myAudio;
    // logic for reloading 
            // check for ammo 
            // if current ammmo not 0 then shoot 
            // while shoot (space), subtract from current ammo
            // if current ammo = 0, cannot shoot 

    void Start() 
    {
        // Initialize the ammo clip in the keyboard 
        currentAmmo = maxClipSize;
        myAudio = GetComponent<AudioSource>();
    }

       void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && timeSinceLastShot > fireRate)
        {
            if (currentAmmo > 0)
            {
                // You have ammo, so you can shoot.
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                // Subtract one from the current ammo amount.
                currentAmmo--;
                FindObjectOfType<UIUpdater>().UpdateCurrentAmmo(currentAmmo);

                //Audio
                myAudio.clip = fire;
                myAudio.Play();

                //Fire Rate
                timeSinceLastShot = 0f;
            }
            else
            {
                // right now the user cannot shoot if current ammo is 0, 
                // can implement additional logic
                // for when the user runs out, message or sound 
            }
        }
        // logic to allow for reloading the keyboard
        if (Input.GetKeyDown (KeyCode.R)){
            Reload(); 
        }
    }
    // method for reloading, set the current ammo amt to the max clip 
    void Reload()
    {
        // Refill the current ammo amount to the max clip size 
        currentAmmo = maxClipSize;
        FindObjectOfType<UIUpdater>().UpdateCurrentAmmo(currentAmmo);

        myAudio.clip = reloadClip;
        myAudio.Play();
    }
}

