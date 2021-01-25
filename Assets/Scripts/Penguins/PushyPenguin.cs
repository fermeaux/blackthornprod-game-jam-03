using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushyPenguin : MonoBehaviour
{
    public float pushForce = 4f;
    public float pushDuration = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            var direction = player.transform.position - transform.position;
            player.Push(new Vector2(direction.x, direction.y), pushForce, pushDuration);
        }
    }
}
