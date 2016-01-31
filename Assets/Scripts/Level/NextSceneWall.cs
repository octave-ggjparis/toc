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

    [SerializeField]
    private Narrator narrationScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!puzzleScript.isPuzzleDone())
            {
                failureReactionScript.failureState();
                failureReactionScript.pushPlayerBack();
                narrationScript.setText("Non, non, non ! Je ne peux pas sortir tant que je n’ai pas tout fait !");
            } else
            {
            Debug.Log("next scene");
                onNextScene.Invoke();
                SceneChangeScript.NextScene();
            }
        }
    }
}
