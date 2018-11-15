using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugType{

    public readonly int Id; 
    public readonly string Name;
    public readonly bool IsHiveWalker;
    public readonly int StepCount;
    public readonly int playerID;

    /// <summary>
    /// use with BugTypeFactory.CreateBugType(int bugId)
    /// </summary>
    /// <param name="bId"></param>
    /// <param name="bName"></param>
    /// <param name="bHWalk"></param>
    /// <param name="stepCount"></param>
    public BugType(int bId, string bName, bool bHWalk, int stepCount, int pId)
    {
        Id = bId;
        Name = bName;
        IsHiveWalker = bHWalk;
        StepCount = stepCount;
       
    }


}

/// <summary>
/// Create a new BugType from a static list
/// 
/// TODO: read from data file
/// </summary>
static class BugTypeFactory{
    static readonly public Dictionary<string, int> bugIdToName = new Dictionary<string, int>()
    {
        {"Empty",0 },
        {"Bee",1},
        {"Ant",2},
        {"Spider",3},
        {"Grasshopper",4},
        {"Worm",8},
        {"Mosquito",6},
        {"LadyBug",7},
        {"Beatle",5},

    };

    static readonly public Dictionary<int, string> bugName = new Dictionary<int, string>()
    {
        {0,"Empty"},
        {1,"Bee"},
        {2,"Ant"},
        {3,"Spider"},
        {4,"Grasshopper"},
        {5,"Beatle"},
        {6,"Mosquito"},
        {7,"LadyBug"},
        {8,"Worm"}

    };

    static readonly public Dictionary<int, bool> bugIsHiveWalker = new Dictionary<int, bool>()
    {
        {0,false},
        {1,false},
        {2,false},
        {3,false},
        {4,false},
        {5,true},
        {6,false},
        {7,true},
        {8,true}

    };

    static readonly public Dictionary<int, int> bugStepCount = new Dictionary<int, int>()
    {
        {0,0},
        {1,1},
        {2,int.MaxValue},
        {3,3},
        {4,int.MaxValue},
        {5,1},
        {6,1},
        {7,3},
        {8,3}

    };
    /// <summary>
    /// contains the starting number of bugs per BugType
    /// </summary>
    static readonly public Dictionary<int, int> bugDefaultCount = new Dictionary<int, int>()
    {
        {1, 1},
        {2, 3},
        {3, 2},
        {4, 3},
        {5, 2},
        {6, 1},
        {7,1 },
        {8, 1},
      };
        
        


    /// <summary>
    /// return with a constructed BugType
    /// if the bugId not in the list set to default:0
    /// </summary>
    /// <param name="bugId"></param>
    /// <returns></returns>
    static public BugType CreateBugType(int bugId, int PId)
    {
        if (bugId >= bugIdToName.Count || bugId < 0)
        {
            Debug.LogError("Wrong BugId!!! Must be in 0->" + bugIdToName.Count + " The Bug type is set to Empty:0");
            bugId = 0;
        }

        //TODO:
        //Make it work for player 2!!!!
        return new BugType(bugId, bugName[bugId], bugIsHiveWalker[bugId], bugStepCount[bugId],PId);

    }


    /// <summary>
    /// if no player id given to CreateBugType() it creats an empty bugType
    /// </summary>
    /// <param name="bugId"></param>
    /// <returns></returns>
    static public BugType CreateBugType(int bugId)
    {
        bugId = 0;
        int PId = 0;
        if (bugId >= bugIdToName.Count || bugId < 0)
        {
            Debug.LogError("Wrong BugId!!! Must be in 0->" + bugIdToName.Count + " The Bug type is set to Empty:0");
            bugId = 0;
        }

        //TODO:
        //Make it work for player 2!!!!
        return new BugType(bugId, bugName[bugId], bugIsHiveWalker[bugId], bugStepCount[bugId], PId);
    }
    static public BugType CreateDefault()
        {
            int bugId = 0;
            int PId = 0;
            if (bugId >= bugIdToName.Count || bugId < 0)
            {
                Debug.LogError("Wrong BugId!!! Must be in 0->" + bugIdToName.Count + " The Bug type is set to Empty:0");
                bugId = 0;
            }
            return new BugType(bugId, bugName[bugId], bugIsHiveWalker[bugId], bugStepCount[bugId], PId);
    }




}