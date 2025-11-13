using Zenject;

public class SceneToolsInstaller : MonoInstaller
{
    //[SerializeField] private SceneLoader sceneLoaderPrefab;


    public override void InstallBindings()
    {
        InstallSceneLoader();
        InstallWaitForSecondsPool();
    }

    private void InstallSceneLoader()
    {
        //Container.Bind<SceneLoader>().FromComponentInNewPrefab(sceneLoaderPrefab).AsSingle();
    }

    private void InstallWaitForSecondsPool()
    {
        Container.Bind<WaitForSecondsPool>().AsSingle().NonLazy();
    }
}