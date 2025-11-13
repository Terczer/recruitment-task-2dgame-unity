using UnityEngine;
using Zenject;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private MenusManager menusManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerSpawner playerSpawner;
    private PlayerControls controls;

    [Inject]
    public void Setup(MenusManager menusManager, PlayerSpawner playerSpawner, EnemySpawner enemySpawner)
    {
        this.menusManager = menusManager;
        this.playerSpawner = playerSpawner;
        this.enemySpawner = enemySpawner;
    }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.UI.Pause.performed += ctx =>
        {
            StopGame();
            ResetGame();
        };
    }

    private void OnEnable()
    {
        menusManager.OnGameStarted += StartGame;
        controls.Enable();
    }

    private void OnDisable()
    {
        menusManager.OnGameStarted -= StartGame;
        controls.Disable();
    }


    #region Game Control Methods
    public void ResetGame()
    {
        playerSpawner.PlayerController.Reset();
        enemySpawner.Reset();
    }

    public void StartGame()
    {
        playerSpawner.PlayerController.DisplayAndMove(true);
        enemySpawner.Spawn();
    }

    public void StopGame()
    {
        enemySpawner.DisplayAndMoveAll(false);
        playerSpawner.PlayerController.DisplayAndMove(false);
        menusManager.CloseAllMenus();
        menusManager.MainMenuController.Display(true);
    }
    #endregion
}
