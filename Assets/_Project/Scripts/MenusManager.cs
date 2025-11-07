using System;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    [SerializeField] private MenuController mainMenuController;
    [SerializeField] private MenuController settingsMenuController;

    public MenuController MainMenuController { get => mainMenuController; }
    public MenuController SettingsMenuController { get => settingsMenuController; }

    public event Action OnGameStarted;


    private void Start()
    {
        CloseAllMenus();
        mainMenuController.Display(true);
    }

    #region Menu Methods
    public void CloseAllMenus()
    {
        mainMenuController.Display(false);
        settingsMenuController.Display(false);
    }

    internal void StartGameplay()
    {
        CloseAllMenus();
        OnGameStarted?.Invoke();
    }
    #endregion
}
