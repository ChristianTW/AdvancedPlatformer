using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using RandularSystems.GamePlay2D;

public class SpikeScript : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.gameObject.GetComponent<PlayerCharacter2D>().isHurt)
            {
                other.gameObject.GetComponent<PlayerHealth>().Damage(20);
            }
        }
    }

}
