using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private Planet parentPlanet;
    private Ressources ressources;
    private Buildings building;
    private bool empty;

    public void setRessources(Ressources pRessources)
    {
        ressources = pRessources;
    }

    public void build(Buildings pBuilding)
    {
        if (this.empty && pBuilding.getBuildingValue() < ressources.getMoney())
        {
            this.building = pBuilding;
            this.building.setLvl(0);
            this.empty = false;
            this.ressources.looseMoney(this.building.getBuildingValue());
        }
        else
        {
            Destroy(pBuilding);
        }
    }

    public void upgrade()
    {
        if (this.building.upgradesValues[this.building.getLvl()] <= this.ressources.getMoney())
        {
            this.ressources.looseMoney(this.building.upgradesValues[this.building.getLvl()]);
            this.building.Upgrade();
        }
    }

    public void active()
    {
        if (this.building.getOnCd())
        {
            this.building.Active();
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

    public void setPlanet(Planet pPlanet)
    {
        this.parentPlanet = pPlanet;
    }

    public Planet getPlanet() { return this.parentPlanet; }
}
