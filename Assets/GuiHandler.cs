using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GuiHandler : MonoBehaviour
{

    public PlayerHandler[] players;

    private int Round;

    public BugType PlaceSelectedBug()   
    {

        Round++;
        Debug.Log(string.Format("round {0}, player: {1}", Round, WhosTurnIs()));
        return players[WhosTurnIs()].PlaceSelectedBug();
        

        
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

        Debug.Log(Round+"before");
        if (Round % 2  == 0)
        {
        
            return 1;
        }
        
        else{

            return 0;
        }
    }

    private void Update()
    {
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
    

