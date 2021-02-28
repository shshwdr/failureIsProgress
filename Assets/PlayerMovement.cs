using Cinemachine;
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
    //public GameObject gameOverUI;
    public bool isDead;
    public bool isFullyDead;
    public bool isUnderground;
    Rigidbody2D rb;
    Collider2D collider;

    List<GameObject> activePositions;
    public CinemachineVirtualCamera cineCam;
    public GameObject spawnPositions;
    int currentSpawnPoint = 0;
    bool isSelectingSpawnPoint = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (isFullyDead)
            {
                if (Input.GetKeyDown(KeyCode.R) && !isSelectingSpawnPoint)
                {
                    SelectSpawnPoint();
                }
                if (isSelectingSpawnPoint)
                {
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        currentSpawnPoint++;
                        updateCamera();
                    }
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        currentSpawnPoint--;
                        updateCamera();
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Respawn();
                    }
                }
            }
            
            return;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal");
        //Debug.Log("horizontal move " + horizontalMove);
        verticalMove= Input.GetAxisRaw("Vertical");
        float speed = Mathf.Abs(horizontalMove);
        if (isUnderground)
        {
            speed = Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove);
            movement.x = horizontalMove;
            movement.y = verticalMove;

            movement = Vector2.ClampMagnitude(movement, 1);
        }
        animator.SetFloat("speed", speed);
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
        animator.SetBool("jump", false);
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

    public void FullyDie()
    {
        isFullyDead = true;
    }

    public void Die(bool destoryPlayerCollider = true)
    {
        isDead = true;
        animator.SetTrigger("die");
        animator.SetBool("jump",false);
        if (destoryPlayerCollider)
        {

            collider.enabled = false;
            rb.gravityScale = 0;
            rb.simulated = false;
        }
    }

    public void updateCamera()
    {
        if (currentSpawnPoint>= activePositions.Count)
        {
            currentSpawnPoint = 0;
        }
        if (currentSpawnPoint <0)
        {
            currentSpawnPoint = activePositions.Count-1;
        }
        cineCam.Follow = activePositions[currentSpawnPoint].transform;
    }

    public void SelectSpawnPoint()
    {
        Dialogues.Instance.hideGameOverText();
        activePositions = new List<GameObject>();

        Dialogues.Instance.showActionText("selectSpawn");
        isSelectingSpawnPoint = true;
        currentSpawnPoint = 0;
        float closestDistance = 100000000;
        for (int i= 0;i < spawnPositions.transform.childCount; i++)
        {
            var go = spawnPositions.transform.GetChild(i).gameObject;
            if (go.active)
            {
                activePositions.Add(go);
                if ((go.transform.position - transform.position).magnitude< closestDistance)
                {
                    closestDistance = (go.transform.position - transform.position).magnitude;
                    currentSpawnPoint = activePositions.Count -1;
                }

            }
        }
        updateCamera();
    }
    public void Respawn()
    {
        transform.position = activePositions[currentSpawnPoint].transform.position;
        isDead = false;
        isFullyDead = false;
        collider.enabled = true;
        rb.simulated = true;
        rb.gravityScale = 1;
        Dialogues.Instance.hideActionText();
        isSelectingSpawnPoint = false;
        cineCam.Follow = transform;
        isUnderground = false;
        animator.Rebind();
        animator.Update(0f);
    }
}
