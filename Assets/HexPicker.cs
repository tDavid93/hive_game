using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPicker : MonoBehaviour {



   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string test()
    {
        return "done";
    }

    public static implicit operator HexPicker(HexMap v)
    {
        throw new NotImplementedException();
    }
}
