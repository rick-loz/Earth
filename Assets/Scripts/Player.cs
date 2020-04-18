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

    }

    public void right()
    {

    }

    public void up() 
    {
        menu.open(true);
    }

    public void down() 
    {
        menu.close();
    }
}
