using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    [SerializeField]
    private Narrator narratorScript;

	public void showTuto(Puzzle currentPuzzle)
    {
        switch(currentPuzzle.getStep())
        {
            case 0 :
                narratorScript.setText("Hum, je dois sortir, je n’ai plus besoin de l’autre…");
                break;

            case 1:
                narratorScript.setText("Éteindre les lumières à la fin et toujours reproduire dans l’ordre de ce que l’on a appris…");
                break;

            case 2:
                narratorScript.setText("Toujours le même nombre… pour chacun…");
                break;
        }
    }
}
