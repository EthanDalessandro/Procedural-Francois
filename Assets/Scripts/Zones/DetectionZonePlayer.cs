using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZonePlayer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyTargetPoint"))
        {
            Vector3 heading = other.transform.position - this.transform.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                if (!other.CompareTag("EnemyTargetPoint")) return;
                
                PlayerWeapon attackScript = GetComponentInParent<PlayerWeapon>();
                attackScript.EnemyInRange(other.transform.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyTargetPoint"))
        {
            PlayerWeapon attackScript = GetComponentInParent<PlayerWeapon>();
            attackScript.ResetVision();
        }
    }
    
}
