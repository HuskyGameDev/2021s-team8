using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleSpikesScript : MonoBehaviour
{
    private bool isOut = false; //boolean that keeps track of whether the spikes are out or not.
    [SerializeField] private float cycleLength;


    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        InvokeRepeating("Cycle", 0, cycleLength); //Every cycleLength seconds, the Cycle method will be called.
    }

    /**
     * Whenever cycle is called, the spikes will either pop out or retract, depending on if they are already out or not.
     * 
     **/
    public void Cycle()
    {
        if (isOut)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            isOut = false;
        } else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            isOut = true;
        }
    }
}
