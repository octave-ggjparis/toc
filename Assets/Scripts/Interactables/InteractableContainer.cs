using UnityEngine;
using System.Collections;

public class InteractableContainer : MonoBehaviour {

    [SerializeField]
    private Interactable[] items;

    public void fireInteractions()
    {
        foreach(Interactable item in items)
        {
            item.Interact();
        }
    }
}
