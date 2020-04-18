using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private Ressources ressources;
    private Slices parentSlice;

    private int lvl;
    private bool onCd = true;

    public int buildingValue;
    public int[] upgradesValues;
    public int[] cd;
    public int sellValue;
    
    public int getBuildingValue() { return buildingValue; }

    public int getSellValue() { return sellValue; }
    
    public void Upgrade() { }

    public void Active() { }

    public void Sell() { }

    public Ressources getRessources() { return this.ressources; }

    public void Built() {}

    public int getLvl() { return lvl; }

    public void addLvl() { this.lvl++; }

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
}
