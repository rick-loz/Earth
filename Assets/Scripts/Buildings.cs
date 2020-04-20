using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buildings : MonoBehaviour
{
    private Ressources ressources;
    private Slices parentSlice;

    private int lvl;
    private bool onCd = true;

    public int maxLvl;
    public int buildingValue;
    public int[] upgradesValues;
    public int[] cd;
    public int sellValue;

    public Slices getParentSlice() { return parentSlice; }

    public int getBuildingValue() { return buildingValue; }

    public int getUpgradesValue(int i) { return upgradesValues[i]; }

    public int getCd(int i) { return cd[i]; }

    public int getSellValue() { return sellValue; }

    public abstract void Upgrade();

    public abstract void Active();

    public abstract void Sell();

    public Ressources getRessources() { return this.ressources; }

    public void setRessources(Ressources pRessources) { this.ressources = pRessources; }

    public abstract void Built();

    public int getLvl() { return lvl; }

    public void addLvl()
    {
        this.sellValue += this.upgradesValues[this.lvl] / 2;
        this.lvl++;
    }

    public bool getOnCd() { return this.onCd; }

    public IEnumerator startCd()
    {
        this.onCd = false;
        float elapsed = 0.0f;
        while (elapsed < this.cd[this.lvl])
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        this.onCd = true;
    }

    public string stringCost()
    {
        return( "Cost :" + buildingValue + " $");
    }

    public string stringSell()
    {
        return ("Sell :" + sellValue + "$");
    }

    public string stringUpgradeCost()
    {
        if (this.getMaxLvl() == this.getLvl())
        {
            return "maxlvl";
        }
        return ("Cost : " + this.getUpgradesValue(this.getLvl()) + "$");
    }

    public abstract string stringUsage();

    public abstract string stringActive();

    public abstract string stringActiveCost();

    public abstract string stringUpgrade();

    public int getMaxLvl() { return (this.maxLvl); }

    public void setLvl(int pLvl) { this.lvl = pLvl; }
    public void setParentSlice(Slices pSlice) { this.parentSlice = pSlice; }
}
