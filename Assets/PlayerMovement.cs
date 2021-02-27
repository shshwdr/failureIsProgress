using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController2D controller;

    Animator animator;
    public float runSpeed = 4f;
    public float undergroundSpeed = 4f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    Vector2 movement;
    bool jump = false;
    bool crouch = false;
    public GameObject gameOverUI;
    bool isDead;
    public Transform spawnPosition;
    public bool isUnderground;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }
            return;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove= Input.GetAxisRaw("Vertical");
        float speed = Mathf.Abs(horizontalMove);
        if (isUnderground)
        {
            speed = Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove);
            movement.x = horizontalMove;
            movement.y = verticalMove;

            movement = Vector2.ClampMagnitude(movement, 1);
        }
        animator.SetFloat("Speed", speed);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        };
        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //};
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }
    private void FixedUpdate()
    {
        if (isUnderground)
        {

            rb.MovePosition(rb.position + movement * undergroundSpeed * Time.fixedDeltaTime);
            //flip
        }
        else
        {

            controller.Move(horizontalMove*runSpeed * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }

    public void Die()
    {
        isDead = true;
        gameOverUI.SetActive(true);
    }
    public void Respawn()
    {
        transform.position = spawnPosition.position;
        isDead = false;

        gameOverUI.SetActive(false);
    }
}
