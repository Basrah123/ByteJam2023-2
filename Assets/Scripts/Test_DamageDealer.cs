using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;
    private void OnCollisionEnter(Collision collision)
    {
        
        Health healthComponent = collision.gameObject.GetComponent<Health>();
        if(healthComponent != null)
        {
            healthComponent.DamageHealth(damageAmount);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Health healthComponent = other.GetComponent<Health>();

        if (healthComponent != null)
        {
            healthComponent.DamageHealth(damageAmount);
        }
    }
}
    
