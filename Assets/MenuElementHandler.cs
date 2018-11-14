using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuElementHandler : MonoBehaviour {

    // Use this for initialization
    public int bugId;
    public BugType MenuType;

    private void Start()
    {
        MenuType = new BugType(bugId);
    }
}
