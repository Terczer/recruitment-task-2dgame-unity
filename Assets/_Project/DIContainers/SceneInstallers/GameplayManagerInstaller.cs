using UnityEngine;
using Zenject;

public class GameplayManagerInstaller : MonoInstaller
{
    [SerializeField] private GameplayManager gameplayManagerPrefab;
    [SerializeField] private Transform gameplayManagerParent;

    public override void InstallBindings()
    {
        Container.Bind<GameplayManager>().FromComponentInNewPrefab(gameplayManagerPrefab).UnderTransform(gameplayManagerParent).AsSingle().NonLazy();
    }
}