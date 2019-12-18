using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public bool spotted = false;
    public Transform startSight, endSight;
    public GameObject bullet;
    private int numberBullet = 100;
    private float timeDelay = 0;

    private void FixedUpdate()
    {
        Debug.DrawLine(startSight.position, endSight.position, Color.red);
        spotted = Physics2D.Linecast(startSight.position, endSight.position, 1 << LayerMask.NameToLayer("Player"));

        timeDelay += Time.deltaTime;
        if (timeDelay > 0.5f && spotted && numberBullet > 0)
        {
            Attack();
            timeDelay = 0;
        }
    }

    void Attack()
    {
        numberBullet--;
        if (gameObject.transform.localScale.x == 5)
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            body.GetComponent<AIBullet>().Shoot(1);
        }
        else
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            body.GetComponent<AIBullet>().Shoot(-1);
        }
    }
}
