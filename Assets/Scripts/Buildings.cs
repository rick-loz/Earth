using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private Slices parentSlice;
    private int buildingValue;
    private int upgradeValue;
    private int sellValue;
    
    public int getBuildingValue() { return buildingValue; }

    public int getSellValue() { return sellValue; }
    
    public void upgrade() { }

    public void execute() { }
}
