using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private Menu menu;

    private Planet parentPlanet;
    private Ressources ressources;
    private Buildings building;
    private bool empty;

    public void setRessources(Ressources pRessources)
    {
        ressources = pRessources;
    }

    public void build(GameObject pBuildingPrefab)
    {
        GameObject vBuildingGameObject = Instantiate(pBuildingPrefab,this.transform);
        Buildings vBuilding = vBuildingGameObject.gameObject.GetComponent<Buildings>();
        if (this.empty && vBuilding.getBuildingValue() < ressources.getMoney())
        {
            this.menu.setHasBuilding(true);
            this.building = vBuilding;
            this.building.setLvl(0);
            this.empty = false;
            this.ressources.looseMoney(this.building.getBuildingValue());
        }
        else
        {
            Destroy(vBuildingGameObject);
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
            this.menu.setHasBuilding(false);
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

    public void setMenu(Menu pMenu)
    {
        this.menu = pMenu;
    }

    public bool getIsFull() { return ! this.empty; }
}
