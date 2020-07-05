using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private Menu menu;

    private AudioManager audioManager;
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
        GameObject vBuildingGameObject = Instantiate(pBuildingPrefab);
        vBuildingGameObject.transform.position = buildingSiteOffset;
        vBuildingGameObject.transform.SetParent(this.parentPlanet.transform);

        Buildings vBuilding = vBuildingGameObject.gameObject.GetComponent<Buildings>();
        Debug.Log(this.empty);
        if (this.empty && vBuilding.getBuildingValue() <= ressources.getMoney())
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
            this.audioManager.playBuildSe();
        }
        else
        {
            this.audioManager.playCancelSe();
            Destroy(vBuildingGameObject);
        }
    }

    public void upgrade()
    {
        if (this.building.upgradesValues[this.building.getLvl()] <= this.ressources.getMoney())
        {
            this.audioManager.playUpgradeSe();
            this.ressources.looseMoney(this.building.upgradesValues[this.building.getLvl()]);
            this.building.Upgrade();
        }
        else
            this.audioManager.playCancelSe();
    }

    public void active()
    {
        if (this.building.getOnCd())
        {
            this.audioManager.playActiveSe();
            this.building.Active();
        }
        else
            this.audioManager.playCancelSe();
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
            this.audioManager.playSellSe();
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

    public void setAudioManager(AudioManager pAudioManager) { this.audioManager = pAudioManager; }

    public Buildings getBuildings() { return this.building; }
}
