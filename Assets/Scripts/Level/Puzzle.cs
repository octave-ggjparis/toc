using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

    [SerializeField]
    private string[] sequenceTags;

    [SerializeField]
    private int[] sequenceNumber;

    private int step = 0;

    private int currentPress = 0;

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
            currentPress++;
            Debug.Log("Currentpress: " + currentPress);
            checkForNextStep();
        }
    }

    private void checkForNextStep()
    {
        int neededPress = (step >= sequenceNumber.Length) ? 1 : sequenceNumber[step];

        if (currentPress >= neededPress)
        {
            Debug.Log("Next step");
            currentPress = 0;
            step++;
        }
    }

    public bool isPuzzleDone()
    {
        return step >= sequenceTags.Length;
    }

}
