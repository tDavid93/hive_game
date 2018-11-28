using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GuiHandler : MonoBehaviour
{

    public PlayerHandler[] players;
    public Text RoundDisplay;

    private int Round;

    public BugType PlaceSelectedBug()   
    {

        
        //Debug.Log(string.Format("round {0}, player: {1}", Round, WhosTurnIs()));
        
        if (players[WhosTurnIs()].SelectedEnoughInInventory())
        {
            
            Round++;
            return players[WhosTurnIs()].PlaceSelectedBug();
        }
        else
        {
           return BugTypeFactory.CreateDefault();
        }

        
        

        
    }

    public BugType GetSelectedBugType()
    {
        
        Debug.Log(string.Format("round {0}, player: {1}", Round, WhosTurnIs()));
        return players[WhosTurnIs()].GetSelectedBugType();



    }

    public int getRound()
    {
        return Round;
    }

    /// <summary>
    /// return the id of the player
    /// </summary>
    /// <returns></returns>
     public int WhosTurnIs()
    {

        //Debug.Log(Round+"before");
        if (Round % 2  == 0)
        {
        
            return 0;
        }
        
        else{

            return 1;
        }
    }

    private void Update()
    {
        RoundDisplay.text = WhosTurnIs().ToString();

        if (Input.GetKey("a"))
        {
            Debug.Log(Round);
        }
    }
    private void Start()
    {
        Round = 0;
    }







}

