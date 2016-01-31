using UnityEngine;
using System.Collections;

public class FailureState : MonoBehaviour {

    [SerializeField]
    private GameObject mainCamera;

    private bool isStressed = false;

    private float microtime = 0;

    public void Update()
    {
        microtime += Time.deltaTime * 1.5f;
        microtime = microtime % 1000;

        if(isStressed)
        {
            shakyCam();
        }
    }

    public void calmDown()
    {
        isStressed = false;
        mainCamera.transform.rotation = Quaternion.identity;
    }

    private void shakyCam()
    {
        mainCamera.transform.Rotate(new Vector3(
            0,
            0,
            Mathf.Sin(microtime) / 50
        ));
    }

    public void stress()
    {
        isStressed = true;
    }
}
