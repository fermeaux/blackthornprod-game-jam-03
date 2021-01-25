using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;

    private PlayerStateManager stateManager;
    private Rigidbody2D rb;
    private Camera cam;

    public void Push(Vector2 direction, float force, float duration)
    {
        if (stateManager.state == PlayerState.INVINCIBLE) return;
        rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        stateManager.ChangeStateTemporaly(PlayerState.PUSHED, duration);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        stateManager = GetComponent<PlayerStateManager>();
    }

    private void FixedUpdate()
    {
        if (stateManager.state != PlayerState.PUSHED)
        {
            Vector2 finalVelocity = Vector2.zero;
            if (Input.GetMouseButton(0))
            {
                var targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                var direction = targetPosition - transform.position;
                direction.z = 0;
                targetPosition.z = 0;
                if (direction.magnitude > 0.1f)
                {
                    finalVelocity = direction.normalized * velocity;
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
                }
            }
            rb.velocity = finalVelocity;
        }
        rb.angularVelocity = 0;
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("Menu");
    }
}
