using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public Armor armor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            armor.UpdateShieldSymbol(20);
        }
    }
}
