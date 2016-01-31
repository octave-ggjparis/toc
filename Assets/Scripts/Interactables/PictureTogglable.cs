using UnityEngine;
using System.Collections;

public class PictureTogglable : MonoBehaviour {

    [SerializeField]
    private PlayerTurnBack playerTurnBackScript;

    [SerializeField]
    private GameObject spriteObject;

    public void action()
    {
        spriteObject.SetActive(!spriteObject.activeInHierarchy);
        playerTurnBackScript.turnBack();
    }
}
