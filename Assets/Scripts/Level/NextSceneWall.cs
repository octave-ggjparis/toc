using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class NextSceneWall : MonoBehaviour {

    [SerializeField]
    private UnityEvent onNextScene;

    [SerializeField]
    private SceneChange SceneChangeScript;

    [SerializeField]
    private Puzzle puzzleScript;

    [SerializeField]
    private FailureReaction failureReactionScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            /*if(!puzzleScript.isPuzzleDone())
            {
                failureReactionScript.failureState();
                failureReactionScript.pushPlayerBack();
            } else
            {*/
                onNextScene.Invoke();
                SceneChangeScript.NextScene();
            //}
        }
    }
}
