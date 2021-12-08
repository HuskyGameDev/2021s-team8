using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip dashSound, blueJewelSound, blackJewelSound, redJewelSound, greenJewelSound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        dashSound = Resources.Load<AudioClip>("Dash JR");
        blueJewelSound = Resources.Load<AudioClip>("Blue Jewel Trimmed");
        blackJewelSound = Resources.Load<AudioClip>("Black Jewel Final copy");
        greenJewelSound = Resources.Load<AudioClip>("Green Jewel Final copy");
        redJewelSound = Resources.Load<AudioClip>("Red Jewel Final copy");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Dash":
                audioSrc.PlayOneShot(dashSound);
                break;
            case "Blue Jewel":
                audioSrc.PlayOneShot(blueJewelSound);
                break;
            case "Black Jewel":
                audioSrc.PlayOneShot(blackJewelSound);
                break;
            case "Red Jewel":
                audioSrc.PlayOneShot(redJewelSound);
                break;
            case "Green Jewel":
                audioSrc.PlayOneShot(greenJewelSound);
                break;
        }
    }
}
