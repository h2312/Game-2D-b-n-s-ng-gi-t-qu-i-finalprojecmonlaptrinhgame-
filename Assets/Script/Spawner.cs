using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gameobject;

    [SerializeField]
    private float minHeight;

    [SerializeField]
    private float maxHeight;

    void Start()
    {
        StartCoroutine(CreatePlane());
    }
    IEnumerator CreatePlane()
    {
        yield return new WaitForSeconds(3);

        Vector2 temp = transform.position;
        temp.y += Random.Range(minHeight, maxHeight);
        Instantiate(gameobject, temp, this.transform.rotation);
        StartCoroutine(CreatePlane());

    }
}
