using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour {

    [SerializeField]
    private string[] sequenceTags;

    [SerializeField]
    private int[] sequenceNumber;

    [SerializeField]
    private FailureReaction failState;

    private int step = 0;

    private int currentPress = 0;

    [SerializeField]
    private float pressValidationTimeout = 2f;

    [SerializeField]
    private UnityEvent onSuccessStep;

    [SerializeField]
    private UnityEvent onFailureStep;

    private float currentPressValidation = 0f;
    private bool pressValidation = false;

    void Update()
    {
        if(pressValidation)
        {
            currentPressValidation -= Time.deltaTime;
            if(currentPressValidation <= 0f)
            {
                checkForNextStep();
                pressValidation = false;
            }
        }
    }

    public void CheckIsRightStep(GameObject interationObject)
    {
        Debug.Log("Checking for step");

        if(step >= sequenceTags.Length)
        {
            Debug.Log("Sequence is complete");
            // It's complete
            return;
        }

        if(interationObject.tag == sequenceTags[step])
        {
            Debug.Log("Currentpress: " + currentPress);
            currentPress++;
            currentPressValidation = pressValidationTimeout;
            pressValidation = true;
        } else
        {
            onFailureStep.Invoke();
            resetPress();
        }
    }

    private void checkForNextStep()
    {
        int neededPress = (step >= sequenceNumber.Length) ? 1 : sequenceNumber[step];

        if (currentPress == neededPress)
        {
            Debug.Log("Next step");
            onSuccessStep.Invoke();
            step++;
        } else
        {
            Debug.Log("Fail");
            failState.failureState();
            onFailureStep.Invoke();
        }

        resetPress();
    }

    void resetPress()
    {
        pressValidation = false;
        currentPress = 0;
    }

    public bool isPuzzleDone()
    {
        return step >= sequenceTags.Length;
    }
}
