using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private Ressources ressources;
    private Buildings building;
    private bool empty;

    public void setRessources(Ressources pRessources)
    {
        ressources = pRessources;
    }

    public void build(Buildings pBuilding)
    {
        if (this.empty && pBuilding.getBuildingValue() < ressources.money)
        {
            this.building = pBuilding;
            this.empty = false;
            this.ressources.looseMoney(this.building.getBuildingValue());
        }
        else
        {
            Destroy(pBuilding);
        }
    }

    public void sell()
    {
        if (!this.empty)
        {
            this.ressources.addMoney(this.building.getSellValue());
            this.building.Sell();
            this.empty = true;
        }
    }
}
