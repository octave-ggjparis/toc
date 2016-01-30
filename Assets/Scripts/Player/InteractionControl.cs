using UnityEngine;
using System.Collections;

public class InteractionControl : MonoBehaviour {

    [SerializeField]
    private InteractableContainer[] interactableContainers;

    [SerializeField]
    private PlayerControls playerControlsScript;

    void Update()
    {
        if(!playerControlsScript.isControllable)
        {
            return;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            foreach (InteractableContainer interactableScript in interactableContainers)
            {
                interactableScript.fireInteractions();
            }
        }
    }
}
