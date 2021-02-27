using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByItToSpawn : MonoBehaviour
{
    public GameObject spawnObject;
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
            if (!spawnObject.active)
            {
                spawnObject.SetActive(true);
            }
        }
    }
}
