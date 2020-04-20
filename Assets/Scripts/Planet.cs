using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float duration;
    public int numberSlices;
    public Ressources ressources;
    public int maxWaste;

    private Slices[] slices;
    private int currentSlice;
    private float degreeRotation;
    private Menu menu;

    public GameObject IncineratorPrefab;
    public GameObject DumpingSitePrefab;
    public GameObject FactoryPrefab;
    public GameObject GatePrefab;


    public void startPlanet(Menu pMenu)
    {
        this.menu = pMenu;
        degreeRotation = 360 / numberSlices;
        currentSlice = 0;
        slices = new Slices[numberSlices];
        for (int i = 0; i < numberSlices; i++)
        {
            slices[i] = new Slices();
            slices[i].setRessources(this.ressources);
            slices[i].setPlanet(this);
            slices[i].setMenu(pMenu);
        }
    }

    public void rotate(bool clockwise)
    {
        if (clockwise)
        {
            currentSlice = (currentSlice + 1) % numberSlices;
            StartCoroutine(smoothRotation(1));
        }
        else
        {
            currentSlice -= 1;
            if(currentSlice == -1) { currentSlice = 5; }
            StartCoroutine(smoothRotation(-1));
        }
        this.menu.setHasBuilding(this.slices[this.currentSlice].getIsFull());
    }

    public IEnumerator smoothRotation(int clockwise)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(new Vector3(0,0, from.z + (clockwise * degreeRotation)));

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;


    }

    public void setMaxWaste(int pWaste)
    {
        this.maxWaste = pWaste;
    }

    public int getMaxWaste() { return this.maxWaste; }

    public void setMenuSlices(Menu pMenu)
    {
        for (int i = 0; i < numberSlices; i++)
        {
            this.slices[i].setMenu(this.menu);
        }

    }

    public void buildIncinerator()
    {
        this.slices[this.currentSlice].build(this.IncineratorPrefab);
    }
}
