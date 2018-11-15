using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {


    public readonly int sizeX = 10;
    public readonly int sizeY = 10;
    
    public GameObject HexPrefab;
    public Material[] HexMaterial;
    public Canvas GUI;

    private Hex[,] hexes;
    private Dictionary<Hex, GameObject> hexToGameObjectMap;


    // Use this for initialization
    void Start() {
        GenerateMap();
    }

    void Update()
    {
 
    }

    /// <summary>
    /// Get the Hex object of the hex of the coordinate x,y
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Hex GetHexAt (int x, int y)
    {
        if (hexes == null)
        {
            Debug.LogError("Hexes array not yet instatntiated!!!");
            //throw new UnityException("Hexes array not yet instatntiated!!!");
            return null;
        }

        return hexes[x,y];
    }
    /// <summary>
    /// Gives a list of a Hexes in radius
    /// </summary>
    /// <param name="centerHex"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public List<Hex> GetHexesInRadius(Hex centerHex, int radius)
    {
        List<Hex> results = new List<Hex>();

        for (int dx = -radius; dx < radius-1; dx++)
        {
            for (int dy = Mathf.Max(-radius+1, -dx-radius); dy < Mathf.Min(radius, -dx+radius-1); dy++)
            {
                results.Add(GetHexAt(centerHex.Q + 1 + dx, centerHex.R + dy));
            }

        }

        return results;

    }


    /// <summary>
    /// update the Hex material
    /// </summary>
    /// <param name="hex"></param>
    /// <param name="material"></param>
    public void updateHex(Hex hex, int material)
    { MeshRenderer mr;
        Debug.Log(material);
        hex.TileType = material;
        mr = hexToGameObjectMap[hex].GetComponentInChildren<MeshRenderer>();
        mr.material = HexMaterial[material]; //GUI.GetComponent<GuiHandler>().WhosTurnIs(),
    }



    public void GenerateMap()
    {
         hexes = new Hex[sizeX, sizeY];
        hexToGameObjectMap = new Dictionary<Hex, GameObject>();

        for (int column = 0; column < sizeX; column++)
        {
            for (int row = 0; row < sizeY; row++)
            {
                //Instantiate a Hex

                Hex h = new Hex(column, row);
                hexes[column, row] = h;

               GameObject hexGo = (GameObject)Instantiate(
                    HexPrefab,
                    h.Position(),
                    Quaternion.identity,
                    this.transform
                    );

                //Debug.Log(string.Format("{0} , {1} , {2}", h.Q, h.R, h.S));
                //Debug.Log(string.Format("{0} , ", hexGo.GetComponent<Transform>().localPosition ));
                h.TileType = 0;
                hexToGameObjectMap[h] = hexGo;
                
                hexGo.name = string.Format("HEX: {0},{1}", column, row);
                hexGo.GetComponentInChildren<HexComponent>().Hex = h;
                hexGo.GetComponentInChildren<HexComponent>().HexMap = this;
                hexGo.GetComponentInChildren<HexComponent>().GUICanvas = GUI;

                hexGo.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", column, row);

                MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer>();
                mr.material = HexMaterial[0];
                hexGo.GetComponentInChildren<HexComponent>().mr = mr;
                
                

            }
        }       

        
    }


}
