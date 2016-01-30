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

    private float pushBack = -2000f;
    private float timeout = 2f;

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
        selfBody.AddForce(new Vector2(pushBack, 0f));
        playerControlsScript.isControllable = false;
        failureText.gameObject.SetActive(true);

        currentTimeout = timeout;
        isFailureState = true;
    }

    private void reactiveControls()
    {
        isFailureState = false;
        playerControlsScript.isControllable = true;
        failureText.gameObject.SetActive(false);
    }
}
