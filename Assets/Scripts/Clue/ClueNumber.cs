using UnityEngine;
using System.Collections;

public class ClueNumber : MonoBehaviour {

    [SerializeField]
    private TextMesh ClueText;

    [SerializeField]
    private GameObject[] ObjectsToHide;

    public void RemoveClue()
    {
        ClueText.text = "";
        foreach(GameObject ObjectToHide in ObjectsToHide)
        {
            ObjectToHide.SetActive(true);
        }
    }

    public void AddClue(int number)
    {
        ClueText.text = number.ToString();
        foreach (GameObject ObjectToHide in ObjectsToHide)
        {
            ObjectToHide.SetActive(false);
        }
    }

}
