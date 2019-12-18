using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateBullet());
    }
    IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(2);

        Vector2 temp = transform.position;
        //temp.x -= Random.Range(-1, 1);
        Instantiate(bullet, temp, this.transform.rotation);
        StartCoroutine(CreateBullet());
    }
}
