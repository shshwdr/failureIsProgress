using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByItToSpawn : MonoBehaviour
{
    public GameObject[] spawnObject;
    public string[] showDeathString;
    public bool shouldDestroyself = true;
    public int progressAmount = 0;
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
        if(collision.GetComponent<PlayerMovement>())
        {
            collision.GetComponent<PlayerMovement>().Die();
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
        }

    }
}
