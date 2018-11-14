using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour {

    // Use this for initialization
    public GameObject ButtonPrefab;
    public Dictionary<string, int> bugCount = new Dictionary<string, int>()
    {
        {"Bee", 1},
        {"Ant", 3},
        {"FlatBug",1},
        {"Spider", 2},
        {"Grasshopper", 3},
        {"Worm", 1},
        {"Mosquito", 1},
        {"LadyBug",1 },
        {"Beetle", 2},

    };
    public Dictionary<string, int> bugId = new Dictionary<string, int>()
    {
        {"Bee", 1},
        {"Ant", 2},
        {"Spider", 3},
        {"Grasshopper", 4},
        {"Worm", 8},
        {"Mosquito", 6},
        {"LadyBug",7 },
        {"Beetle", 5},

    };

    public Dictionary<int, string> bugName = new Dictionary<int, string>()
    {
        {1, "Bee"},
        {2,"Ant"},
        {3,"Spider"},
        {4,"Grasshopper"},
        {5,"Beetle"},
        {6,"Mosquito"},
        {7,"LadyBug"},
        {8,"Worm"}

    };

    public string SelectedBug = "Bee";
    public int RoundCount = 0;


    public int GetSelectedBugId()
    {

        return bugId[SelectedBug];
    }


    public void BugSelect(string bugName)
    {
        if (bugCount.ContainsKey(bugName))
        {
            SelectedBug = bugName;
        }
    }

    public GameObject[] Buttons;

    /// <summary>
    /// set a text mesh from the bugCount dict
    /// </summary>
    /// <param name="buttonId"></param>
    private void setBugCountTextMesh(int buttonId)
    {
        Buttons[buttonId].GetComponentInChildren<TextMesh>().text = bugCount[bugName[buttonId + 1]].ToString();
    }




    /// <summary>
    /// update all button text label
    /// </summary>
    private void UpdateAllButtonTextMesh()
    {
        for (int i = 0; i < Buttons.Length - 1; i++)
        {
            setBugCountTextMesh(i);
        }
    }

      

    public void Start()
    {
        for (int i = 0; i < Buttons.Length-1; i++)
        {
            setBugCountTextMesh(i);
        }
       
    }

    public void Update()
    {
        UpdateAllButtonTextMesh();
    }
}
