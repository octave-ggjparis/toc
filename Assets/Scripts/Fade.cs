using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class Fade : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer target;

    private bool isFade = false;

    [SerializeField]
    private bool isIn = true;

    [SerializeField]
    private VignetteAndChromaticAberration vignette;

    void Update()
    {
        if(!isFade)
        {
            return;
        }

        float multiply = 1.5f;

        if(isIn)
        {
            target.color = new Color(
                target.color.r,
                target.color.g,
                target.color.b,
                target.color.a + (Time.deltaTime * multiply)
            );

            vignette.intensity = Mathf.Clamp(vignette.intensity - Time.deltaTime, 0, 1);
        } else
        {
            target.color = new Color(
                target.color.r,
                target.color.g,
                target.color.b,
                target.color.a - (Time.deltaTime * multiply)
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Fade");
            isFade = true;
        }
    }

}
