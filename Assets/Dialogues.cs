using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : Singleton<Dialogues>
{
    int progress;
    static Dictionary<string,string> dialogues = new Dictionary<string, string>()
    {
        {"killedByChest","The seed is penetrated by chestnut." },
        {"killedByInsect","The seed is eaten by insect." },
        {"killedByWater","The seed is drown in water." },
        {"killedByHoe","The seed is cut by hoe." },
        {"killedByBird","The seed is eaten by bird. " },
        {"winGame","The seed found a place next to the large tree. \nSoon the sprout will grow up and generate more and more seed and they will spread to the world." },

        {"spawnNormalTree","\nBut the death is not in vain, it grows into grass. Use it to journey further to the world." },
        {"spawnBlossom","\nMore energy burst from the seed, this time it's more than just grass." },
        {"spawnFlower","\nThe golden flower is going to shine in every conner of the world." },
        {"spawnRoot","The seed fertilize the ground and you can explore underground." },
        {"spawnFern","\nWith the limit oxygen in cave, it grows into fern." },
        {"spawnOnCliff","\nBut the death is not in vain. The bird take it to the cliff and drop it there, the seed start growing on cliff." },
       
        {"spawnLotus","\nBut your death is not in vain, you grow into lotus." },
        {"spawnWheat","\nBut the death is not in vain, it grows into wheat and spread to every place with human. It becomes one of the most popular crops in the world" },
        
        {"increaseProgress","\nThe progress of spreading to the world increased." },
        {"toRestart","\nPress R to respawn." },
        {"keepPlaying","\nThanks for playing. You can keep explore the game." },
        {"toUnderground","Down arrow / S\n\nGo Underground" },
        {"toUpperground","Up arrow / W\n\nGo Upperground" },
        {"selectSpawn","Left / Right arrow to select spawn point.\nSpace to respawn" },


        {"hintForRoot","Ground here looks barren..." },

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
