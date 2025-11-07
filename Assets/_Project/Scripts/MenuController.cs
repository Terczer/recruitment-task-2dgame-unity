using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenusManager menusManager;
    private Canvas canvas;

    public Canvas Canvas { get => canvas; }
    public MenusManager MenusManager { get => menusManager; }

    protected virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
    }


    public void Display(bool state)
    {
        Debug.Log("Display Menu: " + this.name);
        canvas.enabled = state;
    }
}
