using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

    [SerializeField]
    private ClueNumber[] Clues;

    public void GeneratePuzzle()
    {
        foreach(ClueNumber Clue in Clues)
        {
            Clue.RemoveClue();
        }

        ClueNumber ActiveClue = Clues[Random.Range(0, Clues.Length)];
        ActiveClue.AddClue(Random.Range(0, 10));
    }
}
