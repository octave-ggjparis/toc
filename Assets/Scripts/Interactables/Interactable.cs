using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

    [SerializeField]
    private UnityEvent onInteract;

    [SerializeField]
    private UnityEvent onInteractable;

    [SerializeField]
    private UnityEvent onNoLongerInteractable;

    [SerializeField]
    private Puzzle puzzleScript;

    private bool isInteractable;

    private void SetInteractable()
    {
        onInteractable.Invoke();
        isInteractable = true;
    }

    private void SetNotInteractable()
    {
        onNoLongerInteractable.Invoke();
        isInteractable = false;
    }

    // If the object is OK to interact, perform the interaction
    public void Interact()
    {
        if(isInteractable)
        {
            puzzleScript.CheckIsRightStep(gameObject);
            onInteract.Invoke();
        }
    }

    // If the player touch the item, set it at interactable
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("interactable");
            SetInteractable();
        }
    }

    // Remove the interaction ability if the player move away
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("no longer interactable");
            SetNotInteractable();
        }
    }
}
