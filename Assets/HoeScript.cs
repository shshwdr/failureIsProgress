using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeScript : MonoBehaviour
{
    KilledByItToSpawn killScript;
    // Start is called before the first frame update
    void Start()
    {
        killScript = GetComponent<KilledByItToSpawn>();
    }

    public void killScriptVisible(bool isVisible)
    {
        killScript.enabled = isVisible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
