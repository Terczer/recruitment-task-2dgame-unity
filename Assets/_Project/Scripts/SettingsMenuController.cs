using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MenuController
{
    [Header("UI References")]
    [SerializeField] private Button backButton;

    private void OnEnable()
    {
        backButton.onClick.AddListener(BackToMainMenu);
    }

    private void OnDisable()
    {
        backButton.onClick.RemoveListener(BackToMainMenu);
    }


    #region Button Methods
    public void BackToMainMenu()
    {
        MenusManager.CloseAllMenus();
        MenusManager.MainMenuController.Display(true);
    }
    #endregion
}
