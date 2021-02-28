using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByItToSpawn : MonoBehaviour
{
    public GameObject[] spawnObject;
    public string[] showDeathString;
    public bool shouldDestroyself = true;
    public int progressAmount = 0;
    public bool useCollider;
    public bool destoryPlayerCollider = true;
    bool triggered;
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!useCollider)
        {

            colliderPlayer(collision);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useCollider)
        {

            colliderPlayer(collision.collider);
        }
    }

    IEnumerator fullyKill()
    {
        yield return new WaitForSeconds(1.5f);
        Dialogues.Instance.showGameOverText(showDeathString);
        foreach (var ob in spawnObject)
        {

            if (ob && !ob.active)
            {
                ob.SetActive(true);
            }
        }
        Dialogues.Instance.addProgress(progressAmount);
        if (shouldDestroyself)
        {
            Destroy(gameObject);
        }
        else
        {
            if (!triggered)
            {

                var newStrings = new string[showDeathString.Length - 1];
                int i = 0;
                foreach (var d in showDeathString)
                {
                    if (d != "increaseProgress")
                    {
                        newStrings[i] = d;
                        i++;
                    }
                }
                showDeathString = newStrings;
            }
            triggered = true;
            progressAmount = 0;
        }
        player.FullyDie();
    }

    void colliderPlayer(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() && !collision.GetComponent<PlayerMovement>().isDead)
        {
            collision.GetComponent<PlayerMovement>().Die(destoryPlayerCollider);
            player = collision.GetComponent<PlayerMovement>();
            StartCoroutine(fullyKill());
        }
    }
}
