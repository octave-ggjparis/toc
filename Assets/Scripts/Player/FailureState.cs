using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class FailureState : MonoBehaviour {

    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private VignetteAndChromaticAberration vignette;

    private bool isStressed = false;
    private bool failure = false;

    private float microtime = 0;

    public void Update()
    {
        if(failure)
        {
            if(vignette.intensity < 1f)
            {
                vignette.intensity = Mathf.Clamp(vignette.intensity + (Time.deltaTime / 1.5f), 0f, 1f);
            } else
            {
                SceneManager.LoadScene(Application.loadedLevel);
            }
        }

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
        if(isStressed)
        {
            Debug.Log("failState");
            failure = true;
            return;
        }
        
        isStressed = true;
    }
}
