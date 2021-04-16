using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWallBehavior : MonoBehaviour
{
    [SerializeField] private PressurePlateBehavior PressurePlate; //script of pressure plate that activates the spike wall
    [SerializeField] [Range(1,20)] private float MoveAmount = 1; //distance the spike wall will travel
    [SerializeField] [Range(1,10)] private float MoveSpeed = 1; //speed the spike wall travels at
    private float MoveDistance; //the distance the spike wall has traveled

    // Start is called before the first frame update
    void Start()
    {
        MoveDistance = 0f; //makes sure every time the scene is loaded, the distance traveled is set to zero
    }

    void Update()
    {
        if (PressurePlate.GetIsPressed() && MoveDistance < MoveAmount) //if the pressure plate is pressed and the spike wall hasn't reached its final destination, the spikewall moves
        {
            transform.Translate(0, MoveSpeed * MoveAmount * Time.deltaTime, 0);
            MoveDistance += MoveSpeed * Time.deltaTime;
        }
    }
}
