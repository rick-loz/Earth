using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour
{
    public bool menuIsShowing;
    private RectTransform container;

    // Start is called before the first frame update
    void Start()
    {
        menuIsShowing = false;

        container = GetComponent<RectTransform>();

        container.position = new Vector3(container.rect.width/2.0f, -container.rect.height, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            container.position = new Vector3(container.rect.width / 2.0f, 0.0f, 0.0f);
            menuIsShowing = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            container.position = new Vector3(container.rect.width / 2.0f, -container.rect.height, 0.0f);
            menuIsShowing = false;
        }
    }
}
