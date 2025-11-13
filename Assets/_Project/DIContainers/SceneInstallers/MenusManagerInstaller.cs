using UnityEngine;
using Zenject;

public class MenusManagerInstaller : MonoInstaller
{
    [SerializeField] private MenuController mainMenuController;
    [SerializeField] private MenuController settingsMenuController;
    [SerializeField] private MenusManager menusManagerPrefab;
    [SerializeField] private Transform menusManagerParent;


    public override void InstallBindings()
    {
        Container.Bind<MenusManager>().FromComponentInNewPrefab(menusManagerPrefab).UnderTransform(menusManagerParent).AsSingle().WithArguments(mainMenuController, settingsMenuController).NonLazy();
    }
}