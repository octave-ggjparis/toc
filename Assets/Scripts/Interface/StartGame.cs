using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LoadHouseScene();
        }
    }

	public void LoadHouseScene()
    {
        SceneManager.LoadScene("house");
    }
}
