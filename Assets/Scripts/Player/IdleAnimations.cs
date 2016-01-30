using UnityEngine;
using System.Collections;

public class IdleAnimations : MonoBehaviour {

    [SerializeField]
    private Animator selfAnimator;

    private float IdleWait = 0f;
    private bool isIdleWaiting = false;

    void Update()
    {
        if(selfAnimator.GetBool("isWalking"))
        {
            selfAnimator.ResetTrigger("fixTie");
            selfAnimator.ResetTrigger("lookAround");
            isIdleWaiting = false;
            return;
        }

        if(!isIdleWaiting)
        {
            IdleWait = Random.Range(1, 3);
            isIdleWaiting = true;
        }

        IdleWait -= Time.deltaTime;

        if(IdleWait <= 0)
        {
            bool result = Random.Range(0, 3) > 1;
            if(result)
            {
                selfAnimator.SetTrigger("fixTie");
            } else
            {
                selfAnimator.SetTrigger("lookAround");
            }

            isIdleWaiting = false;
        }
    }
}
