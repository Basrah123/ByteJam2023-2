using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffects : MonoBehaviour
{
    public GameObject hitEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a damaging object
        if (collision.gameObject.CompareTag("DamagingObject"))
        {
            // Instantiate the hit effect at the collision point
            InstantiateHitEffect(collision.contacts[0].point);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the trigger collision is with a damaging object
        if (other.CompareTag("DamagingObject"))
        {
            // Instantiate the hit effect at the trigger's position
            InstantiateHitEffect(other.transform.position);
        }
    }

    void InstantiateHitEffect(Vector3 position)
    {
        // Instantiate the hit effect prefab at the specified position
        Instantiate(hitEffectPrefab, position, Quaternion.identity);
    }
}
