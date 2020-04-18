using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private Ressources ressources;
    private Buildings building;
    private bool empty;

    public void build(Buildings pBuilding)
    {
        if (this.empty && pBuilding.getBuilding() < ressources.money)
        {
            this.building = pBuilding;
            this.empty = false;
            this.ressources.removeMoney(this.building.getBuildingValue());
        }
        else
        {
            destroy(pBuilding);
        }
    }

    public void sell()
    {
        if (!this.empty)
        {
            this.ressources.addMoney(this.building.getSellValue());
            destroy(this.building);
            this.empty = true;
        }
    }
}
