using UnityEngine;
using System.Collections;

public class PlayerTurnBack : MonoBehaviour {

    [SerializeField]
    private LoseControl loseControlScript;

    [SerializeField]
    private Animator playerAnimator;

	public void turnBack()
    {
        loseControlScript.removeControls(0.5f);
        playerAnimator.SetTrigger("turnBack");
    }
}
