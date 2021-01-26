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
            var tags = collision.gameObject.GetComponent<Tags>();
            var isBonus = tags != null && tags.Contains("bonus");
            if (stateManager.GetState() == PlayerState.INVINCIBLE && !isBonus)
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
