using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] private float speed = 5f;
    private Vector2 moveInput;
    private PlayerControls controls;

    public bool CanMove { get => canMove; }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    void Update()
    {
        if (canMove)
        {
            Vector3 move = new Vector3(moveInput.x, moveInput.y, 0f) * speed * Time.deltaTime;
            transform.position += move;

            // Clamp to screen bounds
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);           
        }
    }


    #region Methods
    public override void Reset()
    {
        transform.position = Vector3.zero;
    }
    #endregion
}
