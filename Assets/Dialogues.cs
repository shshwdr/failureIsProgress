using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : Singleton<Dialogues>
{
    int progress;
    static Dictionary<string,string> dialogues = new Dictionary<string, string>()
    {
        {"killedByChest","You are penetrated by chestnut." },

        {"spawnNormalTree","But your death is not nothing, you grow into a tree." },
        {"increaseProgress","The progress of spreading to the world increased." },
        {"toRestart","Press R to respawn." },
        {"toUnderground","Down arrow / S\n\nGo Underground" },
        {"toUpperground","Up arrow / W\n\nGo Upperground" },

        {"dieUnderground","You are too deep underground so you can't sprout." },
        {"fertilize","But the soil is fertilized and the root get grow better" },
    };

    public Text actionText;
    public Text gameoverText;
    public Text hintText;

    public Text progressText;



    public void showText(Text te, string[] dialogTitles)
    {
        string dialogTitle = "";
        foreach(var d in dialogTitles)
        {

            if (!dialogues.ContainsKey(d))
            {
                te.gameObject.SetActive(true);
                te.text = "THIS IS A BUG! action title " + d + "DOES NOT EXISTTTTTT!!!";
                return;
            }
            dialogTitle += dialogues[d];
            dialogTitle += "\n";
        }
        if (te.transform.parent. gameObject.active)
        {
            te.text = "THIS IS A BUG! Action text " + dialogTitle + " was active!!!";
        }
        te.transform.parent.gameObject.SetActive(true);
        te.text = dialogTitle;
    }

    public void hideText(Text te)
    {
        if (!te.transform.parent.gameObject.active)
        {
            te.transform.parent.gameObject.SetActive(true);
            te.text = "THIS IS A BUG! Action text was not active.";
        }
        te.transform.parent.gameObject.SetActive(false);
    }
    public void showActionText(string dialogTitle)
    {
        showText(actionText, new string[] { dialogTitle });
    }

    public void hideActionText()
    {
        hideText(actionText);
    }

    public void showGameOverText(string[] dialogTitle)
    {
        showText(gameoverText, dialogTitle);
    }

    public void hideGameOverText()
    {
        hideText(gameoverText);
    }

    public void addProgress(int p)
    {
        progress += p;
        progressText.text = progress + " %";
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
