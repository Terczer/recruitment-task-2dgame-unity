using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    // TODO: Inject dependency via Zenject
    [SerializeField] private GameplayManager gameplayManager;
    private bool canMove = false;

    public bool CanMove { get => canMove; set => canMove = value; }

    void Update()
    {
        if (canMove)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(h, v, 0f) * speed * Time.deltaTime;
            transform.position += move;

            // Clamp to screen bounds
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameplayManager.ResetGame();
            }            
        }
    }
}
