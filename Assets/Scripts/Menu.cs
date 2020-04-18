﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public EarthRotation er;

    private RectTransform container;

    public GameObject[] buildingButtons;
    public GameObject[] optionButtons;

    public CustomEventSystem customEventSystem;

    private bool isShowingBuildings;

    // Start is called before the first frame update
    void Start()
    {
        isShowingBuildings = true;

        container = GetComponent<RectTransform>();
        container.position = new Vector3(container.position.x, -container.rect.height, 0.0f);
    }

    public void open(bool hasBuilding)
    {
        if(hasBuilding)
        {
            if(isShowingBuildings)
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

                isShowingBuildings = false;

            }
        }
        else
        {
            if(!isShowingBuildings)
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

                isShowingBuildings = true;
            }
        }

        container.gameObject.SetActive(true);
        container.position = new Vector3(container.position.x, 0.0f, 0.0f);

        er.canRotate = false;
    }

    public void close()
    {
        container.position = new Vector3(container.position.x, -container.rect.height, 0.0f);
        container.gameObject.SetActive(false);
        er.canRotate = true;
    }
}