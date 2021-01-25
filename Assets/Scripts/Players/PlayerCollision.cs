using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public UnityEvent onCollide;
    public UnityEvent onPenguinKilled;

    private PlayerStateManager stateManager;

    private void Awake()
    {
        stateManager = GetComponent<PlayerStateManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var penguin = collision.gameObject.GetComponent<PenguinMovement>();
        if (penguin != null)
        {
            if (stateManager.state == PlayerState.INVINCIBLE)
            {
                Destroy(penguin.gameObject);
                onPenguinKilled?.Invoke();
            }
            else
            {
                onCollide?.Invoke();
            }
        }
    }
}
