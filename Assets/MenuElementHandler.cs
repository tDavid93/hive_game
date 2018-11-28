using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuElementHandler : MonoBehaviour {

    //Make and hold a BugType for a button
    public int bugId;
    public BugType MenuType;
    public int CountLeft;
    public GameObject Ph;
    int playerId;


    private void Start()
    {
        
        playerId = Ph.GetComponent<PlayerHandler>().PlayerId;
        Debug.Log(string.Format("PlayerId from Ph.GetComponent<PlayerHandler>().PlayerId: {0}", playerId));
        
        MenuType = BugTypeFactory.CreateBugType(bugId,playerId);
        CountLeft = BugTypeFactory.bugDefaultCount[bugId];

        Debug.Log(string.Format("MenuHandlerInit: PlayerId: {0}, BugName{1}, BugId{2}", MenuType.playerID, MenuType.Name, MenuType.Id));
        //Debug.Log(string.Format(" {0} , {1}",MenuType.Name, MenuType.StepCount ));
    }
}
