using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazePenguin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerStateManager>();
        if (player != null && player.GetState() != PlayerState.INVINCIBLE)
        {
            Destroy(player.gameObject);
        }
    }
}
