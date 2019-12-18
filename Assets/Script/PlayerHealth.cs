using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public Slider healthSlider;

    [SerializeField]
    private GameObject effect;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 0.5f);
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDie();
        }
        
    }

    public void Damage(int dm)
    {
        health -= dm;
        healthSlider.value = health;
    }
}
