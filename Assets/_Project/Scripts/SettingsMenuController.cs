using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MenuController
{
    [Header("UI References")]
    [SerializeField] private Button backButton;

    protected override void OnEnable()
    {
        base.OnEnable();
        backButton.onClick.AddListener(BackToMainMenu);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
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
