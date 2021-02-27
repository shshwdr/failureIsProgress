using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundGenerator : MonoBehaviour
{
    public GameObject undergroundObject;
    public GameObject uppergroundObject;
    public Transform spawnPosition;
    public bool toUnderground;
    bool isTriggering;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toUnderground && isTriggering && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            player.transform.position = spawnPosition.position;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<PlayerMovement>().isUnderground = true;
        }else if (!toUnderground && isTriggering && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {

            player.transform.position = spawnPosition.position;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.GetComponent<PlayerMovement>().isUnderground = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            isTriggering = true;
            player = collision.gameObject;
            if (toUnderground)
            {

                Dialogues.Instance.showActionText("toUnderground");
            }
            else
            {

                Dialogues.Instance.showActionText("toUpperground");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            isTriggering = false;
            Dialogues.Instance.hideActionText();
        }
    }

}
