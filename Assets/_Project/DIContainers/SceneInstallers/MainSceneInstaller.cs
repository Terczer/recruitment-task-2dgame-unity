using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private ObjectPool objectPoolPrefab;


    public override void InstallBindings()
    {
        base.InstallBindings();
        InstallBulletPool();
    }

    private void InstallBulletPool()
    {
        Container.Bind<ObjectPool>().FromComponentInNewPrefab(objectPoolPrefab).AsSingle();
    }
}