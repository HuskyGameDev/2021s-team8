using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyFOV fieldOfView;

    private bool lookingRight = false;

    private void Update()
    {
        if (lookingRight)
        {
            fieldOfView.setDirection(fieldOfView.getFOV() / 2f);
        } else {
            fieldOfView.setDirection((float)(fieldOfView.getFOV() / 2f + 180f));
        }
    }
}
