using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

    [SerializeField]
    private PlayerControls controlsScript;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Rigidbody2D playerBody;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            playerBody.AddForce(new Vector2(250f * 10f * 1f * Time.deltaTime, 0f));
            playerAnimator.SetBool("isWalking", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Final scene start");
            controlsScript.isControllable = false;
            isMoving = true;
        }
    }

    public void finalAnim()
    {
        isMoving = false;
        playerAnimator.SetBool("isWalking", false);
    }
}
