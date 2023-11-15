using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        // Ignore the y-component of the direction, to keep the rotation only around the y-axis
        directionToPlayer.y = 0f;

        // Set the rotation to face the player only along the Y-axis
        transform.rotation = Quaternion.LookRotation(directionToPlayer.normalized, Vector3.up);
    }
}
