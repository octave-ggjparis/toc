using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class LevelStart : MonoBehaviour {

    [SerializeField]
    private UnityEvent onLevelStart;

    void Start()
    {
        onLevelStart.Invoke();
    }
}
