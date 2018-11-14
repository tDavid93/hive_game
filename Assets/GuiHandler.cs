using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour {

    public ToggleGroup BugSelecter;
    public int Round = 0;


    private void GetButtonTypes()
    {
        
    }
    
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a"))
        {
            
            foreach (var item in BugSelecter.ActiveToggles())
            {
                if (item.IsActive())
                {


                    Debug.Log(item.name);
                }
            }
            
            
        }
		
	}
}
