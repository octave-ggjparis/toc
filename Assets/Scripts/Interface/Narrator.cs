using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Narrator : MonoBehaviour {

    [SerializeField]
    private Text targetText;

    private Color currentColor;

    private float timeout = 2.5f;
    private float currentTimeout = 0f;

    void Update()
    {
        if(currentTimeout > 0f)
        {
            currentTimeout -= Time.deltaTime;
            return;
        }

        float reduction = Time.deltaTime;

        currentColor = new Color(
            currentColor.r,
            currentColor.g,
            currentColor.b,
            currentColor.a - reduction
        );

        targetText.color = currentColor;
    }

    public void setText(string Content)
    {
        targetText.text = Content;
        currentColor = new Color(1, 1, 1);
        targetText.color = currentColor;
        currentTimeout = timeout;
    }

    public void showText(string content, Color contentColor)
    {
        targetText.text = content;
        currentColor = contentColor;
    }
}
