using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugType : MonoBehaviour {

    static readonly public Dictionary<string, int> bugId = new Dictionary<string, int>()
    {
        {"Empty",0 },
        {"Bee",1},
        {"Ant",2},
        {"Spider",3},
        {"Grasshopper",4},
        {"Worm",8},
        {"Mosquito",6},
        {"LadyBug",7},
        {"Beetle",5},

    };

    static readonly public Dictionary<int, string> bugName = new Dictionary<int, string>()
    {
        {0,"Empty"},
        {1,"Bee"},
        {2,"Ant"},
        {3,"Spider"},
        {4,"Grasshopper"},
        {5,"Beetle"},
        {6,"Mosquito"},
        {7,"LadyBug"},
        {8,"Worm"}

    };


    private int BugId;

    public Dictionary<string, int> BugCount
    {
        get
        {
            return BugCount;
        }

        set
        {
            BugCount = value;
        }
    }


    public string GetBugName()
    {
        return bugName[BugId];
    }
    public int GetBugTypeId()
    {
        return BugId;
    }
    

    public BugType(int bType)
    {
        if (bType >= bugId.Count || bType<0)
        {
            Debug.LogError("Wrong BugId!!! Must be in 0->"+ bugId.Count+ " The Bug type is set to Empty:0");
            bType = 0;
        }
        BugId = bType;
    }
}
