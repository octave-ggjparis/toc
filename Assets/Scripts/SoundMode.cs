using UnityEngine;
using System.Collections;

public class SoundMode : MonoBehaviour {

    [SerializeField]
    private AudioSource sound2;
    [SerializeField]
    private AudioSource sound3;
    [SerializeField]
    private AudioSource sound4;
    [SerializeField]
    private AudioSource sound5;

    private int step = 1;
    public void next()
    {
        step++;
        switch(step)
        {
            case 2:
                sound2.mute = false;
                break;
            case 3:
                sound3.mute = false;
                break;
            case 4:
                sound4.mute = false;
                break;
            case 5:
                sound5.mute = false;
                break;
        }
    }
}
