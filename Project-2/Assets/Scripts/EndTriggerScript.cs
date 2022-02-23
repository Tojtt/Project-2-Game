using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            GameObject playerObs = coll.transform.gameObject;
            if(playerObs.GetComponent<Player>().hasTreasure)
            {
                SceneManager.LoadScene("You Win");
            } else {
                Debug.Log("You Need To Get The Treasure!!  Explore More!!");
            }
            
        }
    }
}
