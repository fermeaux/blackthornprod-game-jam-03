using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPenguin : MonoBehaviour
{
    public float invincibleDuration = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerStateManager>();
        if (player != null)
        {
            player.ChangeStateTemporaly(PlayerState.INVINCIBLE, invincibleDuration);
            Destroy(gameObject);
        }
    }
}
