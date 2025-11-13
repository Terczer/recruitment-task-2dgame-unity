using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject firstButton;
    private PlayerControls controls;
    private MenusManager menusManager;
    private Canvas canvas;

    public Canvas Canvas { get => canvas; }
    public MenusManager MenusManager { get => menusManager; }

    [Inject]
    public void Setup(MenusManager menusManager)
    {
        this.menusManager = menusManager;
    }

    protected virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
        controls = new PlayerControls();
        controls.UI.Tab.performed += ctx => SelectFirst();
    }

    protected virtual void OnEnable()
    {
        controls.Enable();
    }

    protected virtual void OnDisable()
    {
        controls.Disable();
    }


    #region Methods
    private void SetControls(bool state)
    {
        if (state)
            controls.Enable();
        else
            controls.Disable();
    }

    public void Display(bool state)
    {
        Debug.Log($"{state} Display Menu: " + this.name);
        if (canvas.enabled != state) canvas.enabled = state;
        SetControls(state);
        if (state) SelectFirst();
    }

    private void SelectFirst()
    {
        Debug.Log($"SelectFirst {firstButton.name}");
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    #endregion
}
