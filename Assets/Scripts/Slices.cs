using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private Menu menu;

    private Vector3 buildingSiteOffset;
    private Planet parentPlanet;
    private Ressources ressources;
    private GameObject buildingGameObject;
    private Buildings building;
    private bool empty;

    public Slices()
    {
        this.empty = true;
    }
    public void setRessources(Ressources pRessources)
    {
        ressources = pRessources;
    }

    public void build(GameObject pBuildingPrefab)
    {
        GameObject vBuildingGameObject = Instantiate(pBuildingPrefab,this.parentPlanet.transform);
        vBuildingGameObject.transform.position = buildingSiteOffset;
        vBuildingGameObject.transform.eulerAngles = this.parentPlanet.transform.eulerAngles;
        Buildings vBuilding = vBuildingGameObject.gameObject.GetComponent<Buildings>();
        Debug.Log(this.empty);
        if (this.empty && vBuilding.getBuildingValue() < ressources.getMoney())
        {
            Debug.Log("building built");
            this.menu.setHasBuilding(true);
            this.buildingGameObject = vBuildingGameObject;
            this.building = vBuilding;
            this.building.setLvl(0);
            this.building.setRessources(this.ressources);
            this.building.setParentSlice(this);
            this.empty = false;
            this.ressources.looseMoney(this.building.getBuildingValue());
            this.building.Built();
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
            Destroy(this.buildingGameObject);
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

    public void setBuildingSiteOffset(GameObject pBuildingSite) { this.buildingSiteOffset = pBuildingSite.transform.position; }
}
