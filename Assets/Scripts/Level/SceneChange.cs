using UnityEngine;

public class SceneChange : MonoBehaviour {

    [SerializeField]
    private float sceneDistance = 20f;

    [SerializeField]
    private int numberOfScenes = 3;

    [SerializeField]
    private float playerPositionAfterChange = -7.25f;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform cameraTransform;

    private int currentScene = 1;

    // Move the camera and reposition the characters.
    public void NextScene ()
    {
        if(currentScene >= numberOfScenes)
        {
            return;
        }

        currentScene++;
        cameraTransform.position = new Vector3(
            cameraTransform.position.x,
            cameraTransform.position.y - sceneDistance,
            cameraTransform.position.z
        );

        playerTransform.position = new Vector3(
            playerPositionAfterChange,
            playerTransform.position.y - sceneDistance,
            playerTransform.position.z
        );
    }
}
