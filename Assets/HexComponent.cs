using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexComponent : MonoBehaviour
{

    public HexMap HexMap;
    public Hex Hex;
    public List<Hex> Neighbours;
    public MeshRenderer mr;
    public ToggleGroup BugSelecter;


    private MenuHandler menu;



    private void Start()
    {
        //menu = Camera.main.GetComponentInChildren<MenuHandler>();
    }

    /// <summary>
    /// calculate all of direct neighbours and returns a list of it
    /// </summary>
    /// <returns></returns>
    public List<Hex> CalculateNeighbor()
    {
        return HexMap.GetHexesInRadius(Hex, 2);
    }

    /// <summary>
    /// place a bug the map from the menu and subtract 1 from the counter
    /// </summary>
   /* private void PlaceFromMenu()
    {
        int bugId = menu.GetSelectedBugId();

        if (menu.bugCount[menu.SelectedBug] > 0 && Hex.TileType == 0)
        {
            menu.RoundCount++;
            HexMap.updateHex(Hex, bugId);
            menu.bugCount[menu.SelectedBug] = menu.bugCount[menu.SelectedBug] - 1;
            //Debug.Log(menu.bugCount[menu.SelectedBug]);
        }

    }
    
    /// <summary>
    /// Force place the bee title if not placed in the 3. turn
    /// </summary>
    private void PlaceBee()
    {
        if (menu.bugCount["Bee"] > 0 && Hex.TileType == 0)
        {
            menu.RoundCount++;
            HexMap.updateHex(Hex, 1);
            menu.bugCount["Bee"] = menu.bugCount["Bee"] - 1;
            //Debug.Log(menu.bugCount[menu.bugName[1]]);
        }
    }

    private void OnMouseUp()
    {
        /*
        if (menu.RoundCount == 0)
        {
            PlaceFromMenu();
            menu.RoundCount++;
        }
        else
        {
            List<Hex> nb = CalculateNeighbor();
            bool isPlaceable = false;

            //check the neighbours for other bug
            foreach (var item in nb)
            {

            //if any neighbour is a bug isPlaceable = true
                if (item.TileType != 0)
                {
                    isPlaceable = true;
                }
            }


            
            if (isPlaceable)
            {


                if (menu.RoundCount >= 4 && menu.bugCount["Bee"] == 1)
                {
                    PlaceBee();

                }
                else
                {
                    PlaceFromMenu();
                }
                
            }
            
        }
        
  
            //Debug.Log(Camera.main.GetComponentInChildren<MenuHandler>().SelectedBug);

    }
    */
    
}
