using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    
    [Tooltip("Is True When The Initial Dialouge Stage is Over")]
    public bool hasGameStarted = false; 
    [HideInInspector] public int enemiesToKill;

    [SerializeField] private TMP_Text enemiesLeftToKillDisplay;
    [SerializeField] private int minEnemiesToKill;
    [SerializeField] private int maxEnemiesToKill;

    void Start()
    {
        enemiesToKill = Random.Range(minEnemiesToKill, maxEnemiesToKill);
    }

    void Update()
    {
        if (hasGameStarted)
        {
            enemiesLeftToKillDisplay.text = $"E N E M I E S \nL E F T - {enemiesToKill}";

            if (enemiesToKill == 0 && !FindObjectOfType<PlayerMovement>().isPlayerDead)
            {
                FindObjectOfType<GameManager>().WinGame();
            }
            else if(enemiesToKill > 0 && FindObjectOfType<PlayerMovement>().isPlayerDead)
            {
                FindObjectOfType<GameManager>().LoseGame();
            }
        }
    }
}
