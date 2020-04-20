using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float duration;
    public int numberSlices;
    public Ressources ressources;
    public int maxWaste;
    public GameObject buildingSite;

    private GameObject[] slicesGameObject;
    private Slices[] slices;
    private int currentSlice;
    private float degreeRotation;
    private Menu menu;
    private bool isRotating;

    public GameObject IncineratorPrefab;
    public GameObject DumpingSitePrefab;
    public GameObject FactoryPrefab;
    public GameObject GatePrefab;
    public GameObject SlicePrefab;

    public void startPlanet(Menu pMenu)
    {
        isRotating = false;
        this.menu = pMenu;
        degreeRotation = 360 / numberSlices;
        currentSlice = 0;
        slices = new Slices[numberSlices];
        slicesGameObject = new GameObject[numberSlices];

        for (int i = 0; i < numberSlices; i++)
        {
            slicesGameObject[i] = Instantiate(SlicePrefab);
            slicesGameObject[i].transform.parent = this.transform;
            slices[i] = slicesGameObject[i].GetComponent<Slices>();
            slices[i].setRessources(this.ressources);
            slices[i].setPlanet(this);
            slices[i].setMenu(pMenu);
            slices[i].setBuildingSiteOffset(this.buildingSite);
        }
    }

    public void rotate(bool clockwise)
    {
        if(isRotating)
        {
            return;
        }

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

    public IEnumerator smoothRotation(float clockwise)
    {
        isRotating = true;
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

        Debug.Log(to);
        transform.rotation = to;

        isRotating = false;
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
        this.menu.refresh();
    }

    public void buildDumpingSite()
    {
        this.slices[this.currentSlice].build(this.DumpingSitePrefab);
        this.menu.refresh();
    }

    public void buildFactory()
    {
        this.slices[this.currentSlice].build(this.FactoryPrefab);
        this.menu.refresh();
    }

    public void buildPortal()
    {
        this.slices[this.currentSlice].build(this.GatePrefab);
        this.menu.refresh();
    }

    public void sell()
    {
        this.slices[this.currentSlice].sell();
        this.menu.refresh();
    }

    public void active()
    {
        this.slices[this.currentSlice].active();
        this.menu.refresh();
    }

    public void upgrade()
    {
        this.slices[this.currentSlice].upgrade();
        this.menu.refresh();
    }
}
