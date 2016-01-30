using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer[] affectedSprite;

    [SerializeField]
    private GameObject[] lightSources;

    [SerializeField]
    private Material LitMaterial;

    [SerializeField]
    private Material DarkMaterial;

    public void toggleLight()
    {
        foreach(SpriteRenderer itemRender in affectedSprite)
        {
            if (itemRender.material.name == "Day (Instance)")
            {
                itemRender.material = DarkMaterial;
            } else
            {
                itemRender.material = LitMaterial;
            }
        }

        foreach(GameObject lightSource in lightSources)
        {
            lightSource.SetActive(!lightSource.activeInHierarchy);
        }
    }
}
