using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float time = 100f;
    public float timeBurn = 1f;

    private void Awake()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("TimerSlider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = time;
    }

    void Update()
    {
        if (!player) return;
        if (time > 0)
        {
            time -= timeBurn * Time.deltaTime;
            slider.value = time;
        }
        else
        {
            slider.value = 0f;
            Destroy(player);
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDie();
        }
    }
}
