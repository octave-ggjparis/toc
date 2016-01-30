using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FailureReaction : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D selfBody;

    [SerializeField]
    private Text failureText;

    [SerializeField]
    private PlayerControls playerControlsScript;

    [SerializeField]
    private Animator playerAnimator;

    private float pushBack = -2000f;
    private float timeout = 4f;

    private bool isFailureState = false;
    private float currentTimeout = 0f;

    void Update()
    {
        if(isFailureState)
        {
            currentTimeout -= Time.deltaTime;
            if(currentTimeout <= 0f)
            {
                reactiveControls();
            }
        }
    }

    public void failureState()
    {
        playerControlsScript.isControllable = false;
        failureText.gameObject.SetActive(true);
        playerAnimator.SetTrigger("stressEffect");
        playerAnimator.SetBool("isWalking", false);
        playerAnimator.speed = 1f;

        currentTimeout = timeout;
        isFailureState = true;
    }

    public void pushPlayerBack()
    {
        selfBody.AddForce(new Vector2(pushBack, 0f));
    }

    private void reactiveControls()
    {
        isFailureState = false;
        playerControlsScript.isControllable = true;
        failureText.gameObject.SetActive(false);
    }
}
