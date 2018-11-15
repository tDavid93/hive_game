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

        Debug.Log(string.Format("HEX: {0};{1}, SelectedBugId: {2}", Hex.Q, Hex.R, GUI.GetSelectedBugType()));
        HexMap.updateHex(Hex, GUI.PlaceSelectedBug().Id);



    }

    /// <summary>
    /// Force place the bee title if not placed in the 3. turn
    /// </summary>


    private void OnMouseUp()
    {
        Debug.Log(GUI.getRound());
        Debug.Log(string.Format("{0},{1}", Hex.Q, Hex.R));
        if (GUI.getRound() == 0)
        {
            
            PlaceFromMenu();
            
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


                PlaceFromMenu();

            }

        }


        //Debug.Log(Camera.main.GetComponentInChildren<MenuHandler>().SelectedBug);

    }


}

