Kiusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAstro : MonoBehaviour
{
    [SerializeField]Transform spawnpoint;

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.transform.CompareTag("Player"))
        col.transform.position = spawnpoint.position;
        
        
    }
    
}
