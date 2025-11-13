using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MenuController
{
    [Header("UI References")]
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button ExitButton;
   
    protected override void OnEnable()
    {
        base.OnEnable();
        PlayButton.onClick.AddListener(PlayGame);
        SettingsButton.onClick.AddListener(OpenSettings);
        ExitButton.onClick.AddListener(ExitGame);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        PlayButton.onClick.RemoveListener(PlayGame);
        SettingsButton.onClick.RemoveListener(OpenSettings);
        ExitButton.onClick.RemoveListener(ExitGame);
    }


    #region Button Methods
    public void PlayGame()
    {
        MenusManager.StartGameplay();
    }

    public void OpenSettings() 
    {
        MenusManager.CloseAllMenus();
        MenusManager.SettingsMenuController.Display(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
