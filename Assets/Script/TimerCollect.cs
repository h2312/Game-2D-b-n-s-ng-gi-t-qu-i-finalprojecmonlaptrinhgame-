using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("GameplayController").GetComponent<Timer>().time += 10;
        }
    }
}
