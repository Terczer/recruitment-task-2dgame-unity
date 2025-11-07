using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float thresholdDistance = 5f;

    public Transform Player { get => player; set => player = value; }

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    public void StartMovement()
    {
        StartCoroutine(MovementCoroutine());
    }

    public void StopMovement()
    {
        StopAllCoroutines();
    }

    private IEnumerator MovementCoroutine()
    {
        while (true)
        {
            if (player == null) yield break;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Vector3 direction;
            if (distanceToPlayer < thresholdDistance)
            {
                // Run away from player
                direction = (transform.position - player.position).normalized;
            }
            else if (distanceToPlayer >= thresholdDistance)
            {
                // Close up to player
                direction = (player.position - transform.position).normalized;
            }
            else
            {
                yield break;
            }
            Vector3 newPos = transform.position + direction * speed * Time.deltaTime;
            // Clamp to screen
            Vector3 vp = Camera.main.WorldToViewportPoint(newPos);
            vp.x = Mathf.Clamp01(vp.x);
            vp.y = Mathf.Clamp01(vp.y);
            transform.position = Camera.main.ViewportToWorldPoint(vp);
            // Delay
            yield return new WaitForSeconds(0.025f);
        }
    }
}
