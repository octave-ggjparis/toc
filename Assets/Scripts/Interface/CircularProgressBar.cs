using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour {

    [SerializeField]
    private Image fill;

    [SerializeField]
    private Text hits;

    private int hitCounter = 0;
    private float remainingTime = 2f;
    private float currentTime = 0f;
    private bool isCounting = false;
    
    void Update()
    {
        if(!isCounting)
        {
            hitCounter = 0;
            gameObject.SetActive(false);
        }

        currentTime += Time.deltaTime;
        fill.fillAmount = currentTime / remainingTime;

        if(currentTime >= remainingTime)
        {
            isCounting = false;
        }
    }
    
	public void setTime(float time)
    {
        remainingTime = time;
    }

    public void hit()
    {
        hitCounter++;
        if(hitCounter > 9)
        {
            hitCounter = 9;
        }

        currentTime = 0f;
        hits.text = hitCounter.ToString();
        isCounting = true;
    }
}
