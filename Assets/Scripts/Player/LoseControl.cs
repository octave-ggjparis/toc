using UnityEngine;
using System.Collections;

public class LoseControl : MonoBehaviour {

    [SerializeField]
    private PlayerControls playerControlScript;

    [SerializeField]
    private Animator playerAnimator;

    private float currentTimeout = 0f;
    private bool isTimeoutActive = false;

    void Update()
    {
        if(!isTimeoutActive)
        {
            return;
        }

        currentTimeout -= Time.deltaTime;
        if(currentTimeout < 0f)
        {
            playerControlScript.isControllable = true;
            isTimeoutActive = false;
        }
    }

    public void removeControls(float time)
    {
        if(time > currentTimeout)
        {
            currentTimeout = time;
        }

        isTimeoutActive = true;
        playerControlScript.isControllable = false;

        playerAnimator.speed = 1f;
        playerAnimator.SetBool("isWalking", false);
    }
}
