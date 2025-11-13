using UnityEngine;
using Zenject;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private PlayerController playerController;
    private DiContainer container;

    public PlayerController PlayerController { get => playerController; }

    [Inject]
    public void Setup(DiContainer container)
    {
        this.container = container;
    }

    private void Awake()
    {
        Spawn();
    }


    #region Methods
    public void Spawn()
    {
        if (!playerController)
        {
            SpawnIfNull();
        }
        else
        {
        }
    }

    public void SpawnIfNull()
    {
        playerController = container.InstantiatePrefabForComponent<PlayerController>(playerPrefab);
        playerController.DisplayAndMove(false);
    }
    #endregion
}
