using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The bounds of the spawner")]
    private Vector2 m_Bounds;

    [SerializeField]
    [Tooltip("A list of all enemies that can be spawned and their information")]
    private EnemySpawnInfo[] m_Enemies;
    #endregion

    #region Initialization
    private void Awake() {
        StartSpawning();
    }
    #endregion

    #region Spawn Methods
    public void StartSpawning() {
        for (int i = 0; i < m_Enemies.Length; i++) {
            StartCoroutine(Spawn(i));
        }
    }

    private IEnumerator Spawn(int enemyInd) {
        EnemySpawnInfo info = m_Enemies[enemyInd];
        int i = 0;
        bool alwaysSpawn = false;
        if (info.NumberToSpawn == 0) {
            alwaysSpawn = true;
        }
        while (alwaysSpawn || i < info.NumberToSpawn) {
            yield return new WaitForSeconds(info.TimeToNextSpawn);
            float xVal = m_Bounds.x / 2;
            float yVal = m_Bounds.y / 2;

            Vector2 spawnPos = new Vector2(Random.Range(-xVal, xVal), Random.Range(-yVal, yVal));

            spawnPos.x += transform.position.x;
            spawnPos.y += transform.position.y;
            Instantiate(info.EnemyGO, spawnPos, Quaternion.identity);
            if (!alwaysSpawn) {
                i++;
            }
        }
    }
    #endregion
}
