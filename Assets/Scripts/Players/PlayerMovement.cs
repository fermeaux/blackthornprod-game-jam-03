using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public VariableJoystick joystick;

    private PlayerStateManager stateManager;
    private Rigidbody2D rb;
    private Camera cam;
    private string inputType;

    public void Push(Vector2 direction, float force, float duration)
    {
        if (stateManager.GetState() == PlayerState.INVINCIBLE) return;
        rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        stateManager.ChangeStateTemporaly(PlayerState.PUSHED, duration);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        stateManager = GetComponent<PlayerStateManager>();
        inputType = PlayerPrefs.GetString("inputType", "Point");
        if (inputType == "Joystick") joystick.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (stateManager.GetState() != PlayerState.PUSHED)
        {
            Vector2 direction = Vector2.zero;
            Vector2 finalVelocity = Vector2.zero;

            if (inputType == "Joystick")
            {
                direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    var targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                    direction = targetPosition - transform.position;
                }
            }

            if (direction.magnitude > 0.1f)
            {
                finalVelocity = direction.normalized * velocity;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
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
