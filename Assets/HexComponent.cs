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


    public Canvas GUICanvas;


    private GuiHandler GUI;



    private void Start()
    {

        GUI = GUICanvas.GetComponent<GuiHandler>();
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
    /// 
    /// </summary>
    private void PlaceFromMenu()
    {

        Debug.Log(string.Format("HEX: {0};{1}, SelectedBugId: {2}", Hex.Q, Hex.R, GUI.GetSelectedBugType().Id));
        HexMap.updateHex(Hex, GUI.PlaceSelectedBug());



    }

    /// <summary>
    /// Force place the bee title if not placed in the 3. turn
    /// </summary>


    private void OnMouseUp()
    {
        //Debug.Log(GUI.getRound());
        //Debug.Log(string.Format("{0},{1}", Hex.Q, Hex.R));
        if (GUI.getRound() == 0)
        {
            
            PlaceFromMenu();
            return;
            
        }
        else if (GUI.getRound() == 1)
        {
            
            if (Hex.bugType.Id != 0)
            {
                
                return;
            }


            List<Hex> nb = CalculateNeighbor();
                foreach (var item in nb)
                {
                    bool isPlaceable = false;
                    if (item.bugType.Id != 0 )
                    {
                    isPlaceable = true;
                    }

                    if (isPlaceable)
                    {
                        PlaceFromMenu();
                        return;
                    }

                }
            return;
            
        }
        else
        {
            if (Hex.bugType.Id != 0)
            {
                //TODO: Implement the bug selection and movement here
                return;
            }
            List<Hex> nb = CalculateNeighbor();
            bool isPlaceable = true;

            //check the neighbours for playerIds
            foreach (var item in nb)
            {
                Debug.Log("Hex coord:" + item.Q+" " + item.R + "PlayerID of the hex:" + item.bugType.playerID + " PlayerTurnId:" + GUI.WhosTurnIs());
                //if any neighbour is a bug isPlaceable = true
                
                if (item.bugType.playerID == GUI.WhosTurnIs())
                {
                    if (item.bugType.playerID != 3)
                    {


                        isPlaceable = false;
                        Debug.Log(isPlaceable);
                    }
                }

                //Debug.Log(item.PlayerId + " " + GUI.WhosTurnIs());
                
            }



            if (isPlaceable)
            {


                PlaceFromMenu();
                return;

            }
            return;

        }


        //Debug.Log(Camera.main.GetComponentInChildren<MenuHandler>().SelectedBug);

    }


}

