using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("Gameplay");
        }
	}
}
