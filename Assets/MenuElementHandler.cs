using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuElementHandler : MonoBehaviour {

    //Make and hold a BugType for a button
    public int bugId;
    public BugType MenuType;
    public int CountLeft;

    private void Start()
    {

        
        MenuType = BugTypeFactory.CreateBugType(bugId);
        CountLeft = BugTypeFactory.bugDefaultCount[bugId];
        Debug.Log(string.Format(" {0} , {1}",MenuType.Name, MenuType.StepCount ));
    }
}
