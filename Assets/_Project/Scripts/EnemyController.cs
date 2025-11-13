using UnityEngine;

public class EnemyController : CharacterController
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float minThresholdDistance = 5f;
    [SerializeField] private float maxThresholdDistance = 5.2f;
    private Camera cam;
    private float timer;

    public Transform Player { get => player; set => player = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public float MinThresholdDistance { get => minThresholdDistance; }
    public float MaxThresholdDistance { get => maxThresholdDistance; }
    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetMovement(false);
        }
    }

    private void Update()
    {
        if (!canMove || !player) return;

        timer += Time.deltaTime;
        if (timer < 0.025f) return;
        timer = 0f;

        Move();
    }


    #region Methods
    public override void Reset()
    {
        transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
    }

    private void Move()
    {
        float sqrDistance = (transform.position - player.position).sqrMagnitude;
        float minSq = minThresholdDistance * minThresholdDistance;
        float maxSq = maxThresholdDistance * maxThresholdDistance;
        Vector3 direction = Vector3.zero;

        if (sqrDistance < minSq)
        {
            // Run away from player
            direction = (transform.position - player.position).normalized;
        }
        else if (sqrDistance > maxSq)
        {
            // Close up to player
            direction = (player.position - transform.position).normalized;
        }
        else
        {
            // Stop
            return;
        }
        Vector3 newPos = transform.position + direction * speed * Time.deltaTime;
        // Clamp to screen
        Vector3 vp = cam.WorldToViewportPoint(newPos);
        vp.x = Mathf.Clamp01(vp.x);
        vp.y = Mathf.Clamp01(vp.y);
        transform.position = cam.ViewportToWorldPoint(vp);
    }
    #endregion
}
