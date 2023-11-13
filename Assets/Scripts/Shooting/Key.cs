
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

/** These are the functions for the bullets from the keyboard 
  which in this are the 'keys' from the keyboard 
*/
 
  // const variables 
   public float life = 3;
    [SerializeField] int damage = 25;
    // Find functions of these constructors/method 

    void Awake()
    {
        Destroy(gameObject, life); 
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision != null)
        {

            Health targetHealth = collision.gameObject.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.DamageHealth(damage);
            }
            Destroy(this.gameObject);
        }   
    }

    /* allow for the bullets to not destroy the ground/floor/walls/levels or any other items 
    of high importance, might be better to simplify the on collision method to only allow the bullets or 'keys'
    to only affect the the enemies or 'bugs', and only do damage to them
    */

   
}
