using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleSpikesScript : MonoBehaviour
{
    private bool isOut = false;
    [SerializeField] private float cycleLength;


    void Start()
    {
        InvokeRepeating("Cycle", 0, cycleLength);
    }

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
