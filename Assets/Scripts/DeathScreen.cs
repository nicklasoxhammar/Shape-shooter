using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

    public GameMaster gm;

    public void Quit() {
        Debug.Log("APPLICATION QUIT!");
        Application.Quit();
    }

    public void TryAgain() {
        gm.ReloadLevel();

    }
}
