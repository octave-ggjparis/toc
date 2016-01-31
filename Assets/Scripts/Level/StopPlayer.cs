using UnityEngine;
using System.Collections;

public class StopPlayer : MonoBehaviour {

    [SerializeField]
    private AutoMove moveScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        moveScript.finalAnim();
    }
}
