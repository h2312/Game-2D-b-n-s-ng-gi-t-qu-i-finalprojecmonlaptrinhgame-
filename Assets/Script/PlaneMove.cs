using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private int minX;

    [SerializeField]
    private int maxX;

    [SerializeField]
    private GameObject effect;

    // Update is called once per frame
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
            Destroy(gameObject, 1f);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 1);
            //Destroy(Instantiate(bloodplash, transform.position, Quaternion.identity), 5f);
            //Destroy(Instantiate(moneyText, transform.position, Quaternion.identity), 1f);
        }
    }
}
