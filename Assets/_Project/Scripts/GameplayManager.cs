using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // TODO: Inject dependency via Zenject
    [SerializeField] private MenusManager menusManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerController playerController;

    private void OnEnable()
    {
        menusManager.OnGameStarted += StartGame;
    }

    private void OnDisable()
    {
        menusManager.OnGameStarted -= StartGame;
    }


    #region Game Control Methods
    public void ResetGame()
    {
        enemySpawner.DestroyAll();
        playerController.CanMove = false;
        menusManager.MainMenuController.Display(true);
    }

    public void StartGame()
    {
        playerController.CanMove = true;
        enemySpawner.Spawn();
    }

    public void StopGame()
    {

    }
    #endregion
}
