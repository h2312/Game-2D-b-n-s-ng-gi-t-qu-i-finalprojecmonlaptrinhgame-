using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        Vector2 temp = transform.position;
        temp.y -= 20 * Time.deltaTime;
        transform.position = temp;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessageUpwards("Damage", 1);
            Destroy(gameObject);

        }
    }
}
