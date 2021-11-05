using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        defaultKeys = new Dictionary<string, KeyCode>();


    }

    Dictionary<string, KeyCode> defaultKeys;

    // Update is called once per frame
    void Update()
    {

    }



    public bool GetButtonDown( string buttonName )
    {

        if( defaultKeys.ContainsKey(buttonName) == false)
        {
        return false;

        }
        return false;
    }

    public void SetButtonForKey( string buttonName, KeyCode keyCode )
        {
            defaultKeys[buttonName] = keyCode;
        }

}
