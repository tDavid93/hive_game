using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuElementHandler : MonoBehaviour {

    //Make and hold a BugType for a button
    public int bugId;
    public BugType MenuType;
    public int CountLeft;
    int playerId;

    private void Start()
    {
        playerId = this.GetComponentInParent<PlayerHandler>().PlayerId;
        
        MenuType = BugTypeFactory.CreateBugType(bugId,playerId);
        CountLeft = BugTypeFactory.bugDefaultCount[bugId];
        Debug.Log(string.Format(" {0} , {1}",MenuType.Name, MenuType.StepCount ));
    }
}
