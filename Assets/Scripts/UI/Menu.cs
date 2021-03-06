﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private RectTransform container;

    public GameObject[] buildingButtons;
    public GameObject[] optionButtons;

    public CustomEventSystem customEventSystem;
    public TxtWriting txtWriting;

    private bool isShowingBuildings;
    private bool hasBuilding;
    // Start is called before the first frame update
    void Start()
    {
        //isShowingBuildings = true;
        hasBuilding = false;
        container = GetComponent<RectTransform>();
        container.position = new Vector3(container.position.x, -container.rect.height, 0.0f);
    }

    public void open()
    {
        if(hasBuilding)
        {

            foreach(GameObject c in buildingButtons)
            {
                c.SetActive(false);
            }

            foreach (GameObject c in optionButtons)
            {
                c.SetActive(true);
            }

            customEventSystem.SetSelectedGameObject(optionButtons[0]);
        }
        else
        {
            foreach (GameObject c in optionButtons)
            {
                c.SetActive(false);
            }

            foreach (GameObject c in buildingButtons)
            {
                c.SetActive(true);
            }

            customEventSystem.SetSelectedGameObject(buildingButtons[0]);
        }
        this.container.gameObject.SetActive(true);
        this.container.position = new Vector3(container.position.x, 0.0f, 0.0f);
        txtWriting.setOpen(true);
    }

    public void close()
    {
        txtWriting.setOpen(false);
        this.txtWriting.getTxtRessources().setBonusString("", "", "","","");
        container.position = new Vector3(container.position.x, -container.rect.height, 0.0f);
        container.gameObject.SetActive(false);
    }

    public void setHasBuilding(bool pBool) { this.hasBuilding = pBool; }

    public void refresh()
    {
        this.close();
        this.txtWriting.getTxtRessources().setBonusString("","","","","");
        this.open();
    }
}
