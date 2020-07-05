using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    public bool canRotate = true;

    public int numberOfSlices = 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(0.0f, 0.0f, 360.0f / numberOfSlices);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(0.0f, 0.0f, -360.0f / numberOfSlices);
            }
        }
    }
}
