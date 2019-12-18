using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowPlayer : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;

    GameObject target;

    Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessageUpwards("Damage", 3);
            Destroy(gameObject);

        }
    }
}
