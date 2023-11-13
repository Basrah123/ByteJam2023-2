// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// public class KeyBoard : MonoBehaviour
// {
//     // public variables 
//     public Transform bulletSpawnPoint; 
//     public GameObject bulletPrefab; 
//     public float bulletSpeed = 50; 
//     // variables for relaoding 
//     public int currentAmmo, maxClipSize = 24; 
    
//     // logic for reloading 
//             // check for ammo 
//             // if current ammmo not 0 then shoot 
//             // while shoot (space), subtract from current ammo
//             // if current ammo = 0, cannot shoot 

//     void Start() 
//     {
//         // Initialize the ammo clip in the keyboard 
//         currentAmmo = maxClipSize; 
//     }

//        void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             if (currentAmmo > 0)
//             {
//                 // You have ammo, so you can shoot.
//                 var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//                 bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
//                 // Subtract one from the current ammo amount.
//                 currentAmmo--;
//             }
//             else
//             {
//                 // right now the user cannot shoot if current ammo is 0, 
//                 // can implement additional logic
//                 // for when the user runs out, message or sound 
//             }
//         }
//         // logic to allow for reloading the keyboard
//         if (Input.GetKeyDown (KeyCode.R)){
//             Reload(); 
//         }
//     }
//     // method for reloading, set the current ammo amt to the max clip 
//     void Reload()
//     {
//         // Refill the current ammo amount to the max clip size 
//         currentAmmo = maxClipSize; 
//     }
// }