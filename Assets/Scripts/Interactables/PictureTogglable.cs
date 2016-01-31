using UnityEngine;
using System.Collections;

public class PictureTogglable : MonoBehaviour {

    [SerializeField]
    private PlayerTurnBack playerTurnBackScript;

    [SerializeField]
    private SpriteRenderer spriteObject;

    [SerializeField]
    private Sprite sprite1;

    [SerializeField]
    private Sprite sprite2;

    private bool isSprite2 = false;

    public void action()
    {
        Debug.Log("toggle sprite");
        spriteObject.sprite = isSprite2 ? sprite1 : sprite2;
        isSprite2 = !isSprite2;

        playerTurnBackScript.turnBack();
    }
}
