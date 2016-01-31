using UnityEngine;
using System.Collections;

public class PictureTimeout : MonoBehaviour {

    [SerializeField]
    private PlayerTurnBack playerTurnBackScript;

    [SerializeField]
    private GameObject spriteObject;

    [SerializeField]
    private float timeout = 1f;

    private float currentTimeout = 0f;
    private bool isTimeout = false;

    void Update()
    {
        if(!isTimeout)
        {
            return;
        }

        currentTimeout -= Time.deltaTime;
        if(currentTimeout <= 0f)
        {
            isTimeout = false;
            spriteObject.SetActive(false);
        }
    }

    public void action()
    {
        spriteObject.SetActive(true);
        playerTurnBackScript.turnBack();
        currentTimeout = timeout;
        isTimeout = true;
    }
}
