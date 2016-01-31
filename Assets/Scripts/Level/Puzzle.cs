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

    [SerializeField]
    private CircularProgressBar circularProgressScript;

    [SerializeField]
    private GameObject timerObject;

    private int step = 0;

    private int currentPress = 0;

    [SerializeField]
    private UnityEvent onSuccessStep;

    [SerializeField]
    private UnityEvent onFailureStep;

    [SerializeField]
    private Narrator narratorScript;

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

    public bool CheckIsRightStep(GameObject interationObject, float timer = 2f)
    {
        Debug.Log("Checking for step");

        if(step >= sequenceTags.Length)
        {
            Debug.Log("Sequence is complete");
            // It's complete
            return false;
        }

        Debug.Log("Item: " + interationObject.tag + ", needed: " + sequenceTags[step]);

        if(interationObject.tag != sequenceTags[step])
        {
            Debug.Log("Wrong item!");
            failState.failureState();
            onFailureStep.Invoke();
            resetPress();
            narratorScript.setText("Non, ce n’est pas le bon objet ! Je ne vais pas y arriver !");
            return false;
        }

        Debug.Log("Currentpress: " + currentPress);
        currentPress++;
        if(currentPress > 9)
        {
            currentPress = 9;
        }

        currentPressValidation = timer;
        pressValidation = true;

        timerObject.SetActive(true);
        circularProgressScript.setTime(timer);
        circularProgressScript.hit();
        return true;
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
            narratorScript.setText("Non, je dois le faire un nombre exacte de fois… sinon je vais craquer !");
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

    public int getStep()
    {
        Debug.Log("Step " + step);
        return step;
    }
}
