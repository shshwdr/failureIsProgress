using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : Singleton<Dialogues>
{
    static Dictionary<string,string> dialogues = new Dictionary<string, string>()
    {
        {"killedByChest","You are penetrated by chestnut." },

        {"spawnNormalTree","But your death is not nothing, you grow into a tree." },
        {"increaseProgress","The progress of spreading to the world increased." },
        {"toRestart","Press R to respawn." }, 
        {"toUnderground","Down arrow / S\n\nGo Underground" },
    };

    public Text actionText;
    public Text gameoverText;
    public Text hintText;

    public Text progress;

    public void showActionText(string dialogTitle)
    {
        if (!dialogues.ContainsKey(dialogTitle))
        {
            actionText.gameObject.SetActive(true);
            actionText.text = "THIS IS A BUG! action title " + dialogTitle + "DOES NOT EXISTTTTTT!!!";
            return;
        }
        if (actionText.gameObject.active)
        {
            actionText.text = "THIS IS A BUG! Action text " + dialogTitle +  " was active!!!";
        }
        actionText.gameObject.SetActive(true);
        actionText.text = dialogues[dialogTitle];
    }

    public void hideActionText()
    {
        if (!actionText.gameObject.active)
        {
            actionText.gameObject.SetActive(true);
            actionText.text = "THIS IS A BUG! Action text was not active.";
        }
        actionText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
