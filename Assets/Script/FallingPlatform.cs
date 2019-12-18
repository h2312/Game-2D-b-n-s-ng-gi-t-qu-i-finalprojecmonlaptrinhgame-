using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timeDelay;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            StartCoroutine(Falling());
        }
    }

    IEnumerator Falling()
    {
        yield return new WaitForSeconds(timeDelay);
        body.bodyType = RigidbodyType2D.Dynamic;
    }
}
