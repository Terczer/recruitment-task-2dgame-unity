using UnityEngine;
using Zenject;

public class SpawnersInstaller : MonoInstaller
{
    [SerializeField] private PlayerSpawner playerSpawnerPrefab;
    [SerializeField] private EnemySpawner enemySpawnerPrefab;
    [SerializeField] private Transform spawnersParent;

    public override void InstallBindings()
    {
        Container.Bind<PlayerSpawner>().FromComponentInNewPrefab(playerSpawnerPrefab).UnderTransform(spawnersParent).AsSingle().NonLazy();
        Container.Bind<EnemySpawner>().FromComponentInNewPrefab(enemySpawnerPrefab).UnderTransform(spawnersParent).AsSingle().NonLazy();
    }
}