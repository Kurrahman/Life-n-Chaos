using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource jump;
    public AudioSource hit;
    public AudioSource attack;

    private void Start()
    {
        jump.volume = Globals.soundVolume;
        hit.volume = Globals.soundVolume;
        attack.volume = Globals.soundVolume;
    }

    public void jumpSound()
    {
        jump.Play();
    }
    public void hitSound()
    {
        hit.Play();
    }
    public void attackSound()
    {
        attack.Play();
    }
}
