using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxVelocity = 4f;
    public float speed = 10f;
    public float jumpForce = 400f;
    private Animator anim;
    private Rigidbody2D mybody;

    public bool grounded;

    public AudioSource audioSource;
    public AudioClip AudioJump;
    public AudioClip AudioShoot;

    [SerializeField]
    private GameObject bullet;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    
    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (gameObject.transform.localScale.x == 5)
            {
                GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                body.GetComponent<PlayerBullet>().Shoot(1);
            }
            else
            {
                GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                body.GetComponent<PlayerBullet>().Shoot(-1);
            }
            audioSource.PlayOneShot(AudioShoot);
        }
    }

    private void Move()
    {
        float forceX = 0f;
        float forceY = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }
            Vector3 v = transform.localScale;
            v.x = 5f;
            transform.localScale = v;

            anim.SetBool("IsMove", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
                anim.SetBool("IsMove", true);
            }
            Vector3 v = transform.localScale;
            v.x = -5f;
            transform.localScale = v;

            anim.SetBool("IsMove", true);
        }
        else if (h == 0)
        {
            anim.SetBool("IsMove", false);
        }
        mybody.AddForce(new Vector2(forceX, 0));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
                audioSource.PlayOneShot(AudioJump);
            }
            mybody.AddForce(new Vector2(forceX, forceY));
        }
    }
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "EnemyBullet")
    //    {
    //        Destroy(gameObject);
    //        Destroy(Instantiate(effect, transform.position, this.transform.rotation), 0.5f);
    //        GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDie();
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
