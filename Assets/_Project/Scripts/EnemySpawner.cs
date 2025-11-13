using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private int enemiesNumber = 1000;
    private List<EnemyController> enemiesPool = new List<EnemyController>();

    public List<EnemyController> EnemiesPool { get => enemiesPool; }

    [Inject]
    public void Setup(PlayerSpawner playerSpawner)
    {
        this.playerSpawner = playerSpawner;
    }

    #region methods
    public void Spawn()
    {
        if (enemiesPool.Count == 0)
        {
            SpawnIfNull();
        }
        else
        {
            enemiesPool.ForEach(e =>
            {
                e.Display(true);
                e.SetMovement(true);
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
            InitializeEnemy(enemyController);
            enemiesPool.Add(enemyController);
        }
    }

    private void InitializeEnemy(EnemyController enemyController)
    {
        enemyController.Player = playerSpawner.PlayerController.transform;
        enemyController.SetMovement(true);
        enemyController.Display(true);
    }

    public void StopAll()
    {
        enemiesPool.ForEach(x => x.SetMovement(false));
    }

    public void DisplayAndMoveAll(bool state)
    {
        enemiesPool.ForEach(x => {
            x.SetMovement(state);
            x.Display(state);
        });
    }

    public void Reset()
    {
        enemiesPool.ForEach(e => {
            e.Reset();   
        });
    }
    #endregion
}
