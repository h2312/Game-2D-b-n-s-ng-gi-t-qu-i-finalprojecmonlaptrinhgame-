using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLR : MonoBehaviour
{
    private float speed = 2f;

    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private int minX;

    [SerializeField]
    private int maxX;

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        if (temp.x < minX)
        {
            temp.x = minX;
            speed = -speed;
        }
        if (temp.x > maxX)
        {
            temp.x = maxX;
            speed = -speed;
        }
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 0.5f);
            //Destroy(Instantiate(bloodplash, transform.position, Quaternion.identity), 5f);
            //Destroy(Instantiate(moneyText, transform.position, Quaternion.identity), 1f);
        }
        if (collision.gameObject.tag == "Left")
        {
            Destroy(gameObject);
        }
    }
}
