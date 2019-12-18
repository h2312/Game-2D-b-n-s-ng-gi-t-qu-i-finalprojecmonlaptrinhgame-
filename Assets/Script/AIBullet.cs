using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{
    public int direction = 1;
    private bool shooted = false;

    // Update is called once per frame
    void Update()
    {
        if (shooted)
            Attack();
    }

    public void Shoot(int dir)
    {
        direction = dir;
        shooted = true;
    }

    void Attack()
    {
        Vector2 temp = transform.position;
        temp.x += direction * 5 * Time.deltaTime;
        transform.position = temp;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessageUpwards("Damage", 2);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Left" || collision.gameObject.tag == "Right") // dung duong bien
        {
            Destroy(gameObject);
        }

    }
}
