using UnityEngine;
using System.Collections;

public class InteractableContainer : MonoBehaviour {

    [SerializeField]
    private int scene;

    [SerializeField]
    private Interactable[] items;

    [SerializeField]
    private SceneChange sceneChangeScript;

    public void fireInteractions()
    {
        if (sceneChangeScript.getScene() != scene)
        {
            //Debug.Log("Scene: " + scene + ", Not in scene " + sceneChangeScript.getScene());
            return;
        }

        foreach(Interactable item in items)
        {
            item.Interact();
        }
    }
}
