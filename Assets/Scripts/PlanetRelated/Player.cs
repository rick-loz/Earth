using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ressources ressources;
    private bool controlPlanet;

    public int playerNumber;
    public Planet planet;

    public Menu menu;
    
    // Start is called before the first frame update
    void Start()
    {
        controlPlanet = true;
        this.planet.startPlanet(this.menu);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z))
            {
                up();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                down();
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
            {
                left();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                right();
            }
        }
        else if (playerNumber == 2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                up();
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                down();
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                left();
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                right();
            }
        }
    }

    public void left()
    {
        if (this.controlPlanet) this.planet.rotate(false);
    }

    public void right()
    {
        if (this.controlPlanet) this.planet.rotate(true);
    }

    public void up() 
    {
        menu.open();
        controlPlanet = false;
    }

    public void down() 
    {
        menu.close();
        controlPlanet = true;
    }
}
