using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused;
    public Animator _transitionAnimator;

    public DialougeSO unknown_lost;
    public DialougeSO unknown_win;

    [SerializeField] private DialougeSO chosenDialogueSO;
    [SerializeField] private AudioSource gameWinAudio;
    [SerializeField] private AudioSource gameLoseAudio;
    [SerializeField] private AudioSource outroAudio;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "EndScene")
        {
            _transitionAnimator.SetInteger("Transition", 1);

            // Check if Player Won
            string playerWon = PlayerPrefs.GetString("player_won");

            if (playerWon == "playerWon")
            {
                gameWinAudio.Play();
                chosenDialogueSO = unknown_win;
            }
            else if (playerWon == "playerLost")
            {
                gameLoseAudio.Play();
                chosenDialogueSO = unknown_lost;
            }

            // Setting the right Dialogues for the Player
            FindObjectOfType<DialougePlayer>().unknown = chosenDialogueSO;
        }

        if(outroAudio != null) Invoke("PlayOutro", 1);
    }

    void PlayOutro()
    {
        outroAudio.Play();
    }

    private void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void WinGame()
    {
        PlayerPrefs.SetString("player_won", "playerWon");
        SceneTransition("EndScene");
    }

    public void LoseGame()
    {
        PlayerPrefs.SetString("player_won", "playerLost");
        SceneTransition("EndScene");
    }

    public void Retry()
    {
        SceneTransition("MainGame");
    }

    void SceneTransition(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
