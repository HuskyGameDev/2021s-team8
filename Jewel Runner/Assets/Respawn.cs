using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        
         GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
      
    }

}
