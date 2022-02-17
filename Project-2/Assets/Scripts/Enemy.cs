using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    #region Movment_variables
    public float movespeed = 2f;
    private float lastDirectionChange;
    private readonly float directionChangeTime = 3f;
    private Vector2 moveDirection;
    #endregion

    #region Physics_components
    Rigidbody2D EnemyRB;
    #endregion

    #region Targeting_variables
    public Transform player;
    public float playerSize;
    #endregion

    #region Size_variables
    public float maxHealth;
    float currHealth;
    public float size;
    #endregion


    #region Unity_functions
    //run once on creation
    private void Awake() 
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        lastDirectionChange = 0f;
        RandomDirection();
    }
    //run once every frame
    private void Update() 
    {
        //check to see if we know where player is
        if(player != null)
        {
            Chase();
        } else if (Time.time - lastDirectionChange > directionChangeTime)
            {
                lastDirectionChange = Time.time;
                RandomDirection();
            }
    }
    #endregion

    #region Movment_functions
    //move directly at player
    
    private void RandomDirection()
    {
    //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        moveDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        //move enemy: 
        EnemyRB.velocity = moveDirection * movespeed;
        // transform.position = new Vector2(transform.position.x + (movePerSecond.x * Time.deltaTime), 
        // transform.position.y + (movePerSecond.y * Time.deltaTime));
    }
    
    private void Chase()
    {
        //calculate movment vector: player position - enemy position = diction of player relative to enemy
        Vector2 direction = player.position - transform.position;
        EnemyRB.velocity = direction.normalized * movespeed + Vector2.one * size/2;

    }
    #endregion

    #region Collision_functions
    
    // Raycasts box for player, casus damage, spawns explosion prefab
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.transform.CompareTag("Player"))
        {
            GameObject playerObs = collision.gameObject;
            playerSize = playerObs.GetComponent<Player>().size;
            if (size > playerSize)
            {
                Destroy(collision.gameObject);
                SceneManager.LoadScene("Game Over");
                Debug.Log("Game Over! Good Luck Next Time!");
        
            } else if (size < playerSize)
            {
                Debug.Log("Player Size is " + playerSize);
                Destroy(this.gameObject);
                playerObs.GetComponent<Player>().IncreaseSize();
            }
        }
    }
    #endregion

    #region Health_functions
    #endregion
}
