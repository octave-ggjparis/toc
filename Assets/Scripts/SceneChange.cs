using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    [SerializeField]
    private float sceneSize = 24f;

    [SerializeField]
    private int numberOfScenes = 3;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform cameraTransform;

    enum sceneDirection
    {
        PREVIOUS,
        NEXT
    }

    private int currentScene = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
        float positionModifier = sceneSize * currentScene;

        if (playerTransform.position.x < (-sceneSize / 2) - positionModifier)
        {
            float prout = (-sceneSize / 2) + positionModifier;
            Debug.Log("modifier: " + positionModifier + ", position: " + playerTransform.position.x);
            Debug.Log("right: " + prout.ToString());
            ChangeScene(sceneDirection.NEXT);
        } else if(playerTransform.position.x > (sceneSize / 2) - positionModifier)
        {
            ChangeScene(sceneDirection.PREVIOUS);
        }
	}

    // Move the camera and reposition the characters.
    void ChangeScene (sceneDirection direction)
    {
        if(
            (direction == sceneDirection.PREVIOUS && currentScene <= 0) ||
            (direction == sceneDirection.NEXT && currentScene >= numberOfScenes - 1)
        )
        {
            return;
        }

        float cameraMove;
        int sceneModifier;

        if(direction == sceneDirection.NEXT)
        {
            sceneModifier = 1;
            cameraMove = -sceneSize;
        } else
        {
            sceneModifier = -1;
            cameraMove = sceneSize;
        }

        currentScene += sceneModifier;
        cameraTransform.position = new Vector3(
            cameraTransform.position.x + cameraMove,
            cameraTransform.position.y,
            cameraTransform.position.z
        );
    }
}
