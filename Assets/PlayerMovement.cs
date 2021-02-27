using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController2D controller;

    Animator animator;
    public float runSpeed = 4f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public GameObject gameOverUI;
    bool isDead;
    public Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
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
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
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
