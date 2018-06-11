using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    int lives = 3;

    public Text livesUI;

    private static bool paused = false;

    public Image timeBar;
    public float decreaseAmount;



    [SerializeField]
    private GameObject deathScreen;

    [SerializeField]
    private GameObject loseScreen;

    void Awake() {
              
        DontDestroyOnLoad(this);

        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        }
    }

    void Update() {

        if (!paused) {
            timeBar.fillAmount -= decreaseAmount * Time.deltaTime;

            if (timeBar.fillAmount <= 0f) {
                print("oh noes");
            }

        }

        livesUI.text = "Lives: " + gm.lives;

        if (GameObject.FindGameObjectWithTag("EnemyShape") == null) {
            LevelComplete();

        }

    }


    public void LevelComplete() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        timeBar.fillAmount = 1;

    }

    public static void KillPlayer(Player player) {
        Destroy(player.gameObject);
        gm.deathScreen.SetActive(true);

        
    }

    public static void LoseLife(Player player) {
        gm.lives -= 1;

        Destroy(player.gameObject);

        if (gm.lives < 1) {
            gm.loseScreen.SetActive(true);
            paused = true;
        }
        else {
            gm.deathScreen.SetActive(true);
            paused = true;
        }


    }public void DisableDeathScreen() {
        gm.deathScreen.SetActive(false);
        paused = false;
        timeBar.fillAmount = 1;
    }

    public void DisableLoseScreen() {
        gm.loseScreen.SetActive(false);
        paused = false;
        timeBar.fillAmount = 1;
    }

    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DisableDeathScreen();
    }

    public void LoadFirstLevel() {
        lives = 3;
        SceneManager.LoadScene(0);
        DisableLoseScreen();
    }

    




}
