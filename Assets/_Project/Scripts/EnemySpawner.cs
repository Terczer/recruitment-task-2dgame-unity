using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private int enemiesNumber = 1000;
    private List<EnemyController> enemiesPool = new List<EnemyController>();

    public List<EnemyController> EnemiesPool { get => enemiesPool; }


    #region methods
    public void Spawn()
    {
        if (enemiesPool.Count == 0)
        {
            SpawnIfNull();
        }
        else
        {
            enemiesPool.ForEach(x =>
            {
                x.gameObject.SetActive(true);
                x.StartMovement();
            });
        }
    }

    public void SpawnIfNull()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.Player = player;
            enemyController.StartMovement();
            enemiesPool.Add(enemyController);
        }
    }

    public void DestroyAll()
    {
        enemiesPool.ForEach(x => x.StopMovement());
    }
    #endregion
}
