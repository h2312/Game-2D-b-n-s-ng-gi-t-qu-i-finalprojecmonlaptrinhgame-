using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public static DoorScript Instance;
    private Animator anim;
    private BoxCollider2D box;
    private int Score = 0;
    public Text txtScore;

    [HideInInspector]
    public int CollectablesCount;

    [SerializeField]
    private GameObject effectExit;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    IEnumerator DoorOpen()
    {
        anim.Play("DoorOpen");
        yield return new WaitForSeconds(2f);
        box.isTrigger = true;
    }

    public void DecrementCollectables()
    {
        CollectablesCount--;
        Score++; // mỗi lần lấy được diamond thì tăng điểm lên 1 đơn vị
        txtScore.text = "Score: " + Score;

        if (CollectablesCount == 0)
            StartCoroutine(DoorOpen());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject, 1f);
            Destroy(Instantiate(effectExit, collision.transform.position, Quaternion.identity), 1f);
            SceneManager.LoadScene("Level2");
        }
    }
}
