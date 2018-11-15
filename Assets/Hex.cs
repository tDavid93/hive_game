using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Defines the position, world space, size , neighbours, etc ... of a
/// Hex tile.
/// NOT INTERACT WITH UNITY DIRECTLY!!!!!!
/// </summary>
public class Hex
{
    public Hex(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);

    }
    // Q + R + S = 0
    // S =  -1 * (q-r)

    public readonly int Q; //Column
    public readonly int R; //Row
    public readonly int S;

    public int TileType;
    public int PlayerId;



    static readonly float WIDTH_MULTIPLAYER = Mathf.Sqrt(3) / 2;


    /// <summary>
    /// calculate the world position
    /// </summary>
    /// <returns>world position</returns>
    public Vector3 Position()
    {
        float radius = 1f;
        float height = radius * 2;
        float width = WIDTH_MULTIPLAYER * height;

        float horiz = width;
        float vert = height * 0.75f;

        return  new Vector3(
            horiz * (this.Q + this.R / 2f),
            0,
            vert * this.R
            );

    }
}
