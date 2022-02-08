using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
    private float _inpX;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _inpX = Input.GetAxis("Horizontal");
        PlayerBounderys();
    }

    private void FixedUpdate()
    {
        PlayerMovement();

    }
    private void PlayerMovement()
    {
        _rb.velocity = new Vector2(_moveSpeed *_inpX * Time.deltaTime,_rb.velocity.y);
    }

    private void PlayerBounderys()
    {
        if(transform.position.x > 7.9f)
        {
            transform.position = new Vector2(7.9f,transform.position.y);
        }else if (transform.position.x < -7.9f)
        {
            transform.position = new Vector2(-7.9f, transform.position.y);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            if(GameManager.Instance._lifes != 0)
            {
                GameManager.Instance._lifes--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Life") && GameManager.Instance._lifes != 3)
        {
            Destroy(collision.gameObject);
            GameManager.Instance._lifes++;
        }
    }
}
