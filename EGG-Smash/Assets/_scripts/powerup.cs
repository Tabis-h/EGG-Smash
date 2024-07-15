using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public void   OnTriggerEnter(Collider other)
    {
        if(other.name == "Player"){ 
            PlayerController.walkingSpeed *=5f;
           
            Destroy(gameObject);
        }
    }
}
