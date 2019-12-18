using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollowPlayer : MonoBehaviour
{
    GameObject Target;

    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;

    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        Target = GameObject.Find("Player");
    }
    void Update()
    {
        if (Target == null)
            return;

        Vector2 Direction = Target.GetComponent<Transform>().position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2f * Time.deltaTime);

        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
