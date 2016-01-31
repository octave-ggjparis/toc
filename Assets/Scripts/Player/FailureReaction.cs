using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FailureReaction : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D selfBody;

    [SerializeField]
    private LoseControl loseControlsScript;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private float pushBack = -1500f;

    public void failureState()
    {
        playerAnimator.SetTrigger("stressEffect");
        playerAnimator.speed = 1f;
        loseControlsScript.removeControls(4f);
    }

    public void pushPlayerBack()
    {
        selfBody.AddForce(new Vector2(pushBack, 0f));
    }
}
