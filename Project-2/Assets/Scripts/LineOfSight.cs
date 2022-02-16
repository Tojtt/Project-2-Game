using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    //called when soething enters the trigger colider
    private void OnTriggerEnter2D(Collider2D coll) 
    {
        if(coll.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>().player = coll.transform;
            Debug.Log("SEE PLAYER RUN AT PLAYER");
        }   
    }
    
    private void Update() 
    {
        //make sure line of sight is following the parent object
        transform.position = transform.parent.position;
    }
}
