using UnityEngine;
using System.Collections;

public class LoseScreen : MonoBehaviour {

    public GameMaster gm;

    public void Quit() {
        Debug.Log("APPLICATION QUIT!");
        Application.Quit();
    }

    public void TryAgain() {
        gm.LoadFirstLevel();

    }
}
