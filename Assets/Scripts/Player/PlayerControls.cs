using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 10f;

    [SerializeField]
    private Rigidbody2D selfRigidBody;

    [SerializeField]
    private Transform selfTransform;

    [SerializeField]
    private Animator playerAnimator;

    public bool isControllable = true;

    private enum direction
    {
        LEFT,
        RIGHT
    }

    private Vector3 initialScale;
    private direction currentDirection = direction.RIGHT;

	void Awake ()
    {
        initialScale = selfTransform.localScale;
	}
	
	void Update ()
    {
        if(!isControllable)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0.25f || horizontal < 0.25f)
        {
            move(horizontal);
        }

        playerAnimator.speed = Mathf.Clamp(Mathf.Abs(selfRigidBody.velocity.x), 0, 2);
	}

    private void move(float horizontal)
    {
        selfRigidBody.AddForce(new Vector2(25 * maxSpeed * horizontal * Time.deltaTime, 0f));
        selfRigidBody.velocity = new Vector2(
            Mathf.Clamp(selfRigidBody.velocity.x, -maxSpeed, maxSpeed),
            0
        );

        if(
            (horizontal < 0 && currentDirection == direction.RIGHT) ||
            (horizontal > 0 && currentDirection == direction.LEFT)
        )
        {
            Flip();
        }
    }

    private void Flip()
    {
        currentDirection = (currentDirection == direction.LEFT) ? direction.RIGHT : direction.LEFT;

        selfTransform.localScale = new Vector3(
            (currentDirection == direction.LEFT) ? -initialScale.x : initialScale.x,
            initialScale.y,
            1
        );
    }
}
