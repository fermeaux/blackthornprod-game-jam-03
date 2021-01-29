using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinCollision : MonoBehaviour
{
    public List<GameObject> collisionsFx;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            if (collisionsFx.Count > 0)
            {
                var selected = collisionsFx[Random.Range(0, collisionsFx.Count)];
                var point = collision.GetContact(0).point;
                var direction = new Vector2(transform.position.x, transform.position.y) - point;
                var rotation = Quaternion.LookRotation(Vector3.forward, direction);
                Instantiate(selected, point, rotation);
            }
            if (animator != null)
            {
                animator.Play("collide");
            }
        }
    }
}
