using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class NextSceneWall : MonoBehaviour {

    [SerializeField]
    private UnityEvent onNextScene;

    [SerializeField]
    private SceneChange SceneChangeScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneChangeScript.NextScene();
        }
    }
}
