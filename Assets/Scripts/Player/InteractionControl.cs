using UnityEngine;
using System.Collections;

public class InteractionControl : MonoBehaviour {

    [SerializeField]
    private InteractableContainer interactableScript;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            interactableScript.fireInteractions();
        }
    }
}
