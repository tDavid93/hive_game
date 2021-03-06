﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerHandler : MonoBehaviour {

    public int PlayerId;
    public ToggleGroup BugSelecter;
    public Toggle BeeToggle;
    public int PlayerRound;
    public Text roundText;

    

    public bool SelectedEnoughInInventory()
    {

        if (GetSelectedElementHandler().CountLeft > 0)
        {
            return true;
        }
        return false;

    }

    /// <summary>
    /// returns the bee toggle
    /// </summary>
    /// <returns></returns>
    private Toggle GetBeeToggle()
    {
        foreach (var item in BugSelecter.GetToggles())
        {
            if (item.name == "BeeToggle")
            {
                return item;
            }
        }
        return null;
    }
    /// <summary>
    /// returns the slected bug subtract 1 from bugcount in the MenuElementHandler and add 1 to round counter
    /// </summary>
    /// <returns></returns>
    public BugType PlaceSelectedBug()
    {
        Debug.Log("PlaceSelectedBug(): " + GetSelectedBugType().Name);
        //if the bee stays in the inventory in the 4. round then change the active toggle for the bee and return with an empty element
        if (PlayerRound == 3 && BeeToggle.GetComponent<MenuElementHandler>().CountLeft == 1 && BeeToggle.isOn == false)
        {
            BeeToggle.isOn = true;
            return BugTypeFactory.CreateDefault();

        }


        if (SelectedEnoughInInventory())
        {
            PlayerRound++;
            GetSelectedElementHandler().CountLeft--;
            Debug.Log("is enough");
            return GetSelectedBugType();
        }

        Debug.Log("not enough");
        return BugTypeFactory.CreateDefault();
    }

    /// <summary>
    /// get the selected bug type
    /// </summary>
    /// <returns></returns>
    public BugType GetSelectedBugType()
    {

     

        BugType temp = BugSelecter.GetActive().GetComponent<MenuElementHandler>().MenuType;
        Debug.Log("GetSelectedBugType(): "+  BugSelecter.GetActive().GetComponent<MenuElementHandler>().MenuType.Name);
        return temp;

    }
    /// <summary>
    /// returns the MenuElementHandler of the active toggle
    /// </summary>
    /// <returns></returns>
    public MenuElementHandler GetSelectedElementHandler()
    {


        return BugSelecter.GetActive().GetComponent<MenuElementHandler>();

    }

    private void Start()
    {
        // serach the bee toggle
        BeeToggle = GetBeeToggle();
        BeeToggle.isOn = true;
        PlayerRound = 0;
    }
    // Update is called once per frame
    void Update()
    {

        roundText.text = string.Format("Round: {0}", PlayerRound + 1);

        foreach (var item in BugSelecter.GetToggles())
        {
            item.GetComponentInChildren<Text>().text = string.Format("{0}", item.GetComponentInChildren<MenuElementHandler>().CountLeft);
        }



    }
}

public static class ToggleGroupExtension
{
    public static Toggle GetActive(this ToggleGroup aGroup)
    {
        return aGroup.ActiveToggles().FirstOrDefault();
    }


}
public static class ToggleGroupExtensions
{

    private static System.Reflection.FieldInfo _toggleListMember;

    /// <summary>
    /// Gets the list of toggles. Do NOT add to the list, only read from it.
    /// </summary>
    /// <param name="grp"></param>
    /// <returns></returns>
    public static IList<Toggle> GetToggles(this ToggleGroup grp)
    {
        if (_toggleListMember == null)
        {
            _toggleListMember = typeof(ToggleGroup).GetField("m_Toggles", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (_toggleListMember == null)
                throw new System.Exception("UnityEngine.UI.ToggleGroup source code must have changed in latest version and is no longer compatible with this version of code.");
        }
        return _toggleListMember.GetValue(grp) as IList<Toggle>;
    }

    public static int Count(this ToggleGroup grp)
    {
        return GetToggles(grp).Count;
    }

    public static Toggle Get(this ToggleGroup grp, int index)
    {
        return GetToggles(grp)[index];
    }

}

