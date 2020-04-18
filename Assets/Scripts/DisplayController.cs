using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public bool isMenuShowing;
    public int currentSlice; // goes from 1 to number of slices
    public int numberOfSlices;

    // Start is called before the first frame update
    void Start()
    {
        isMenuShowing = false;
        currentSlice = 1;
    }

    // Direction should be only 1 or -1
    public void sliceMove(int direction)
    {
        currentSlice += direction;

        if(currentSlice > numberOfSlices) { currentSlice = 1; }
        else if(currentSlice < 0) { currentSlice = 6; }
    }
}
