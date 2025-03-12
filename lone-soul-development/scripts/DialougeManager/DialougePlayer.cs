using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialougePlayer : MonoBehaviour
{
    public DialougeSO player;
    public DialougeSO unknown;
    public float pauseTime = 2f;

    private DialougeSO currentDialougeHolder;
    private bool canDoNextDialouge = false;

    private Queue<string> sentences;

    [SerializeField] private TMP_Text speakerDisplay;
    [SerializeField] private TMP_Text dialougeDisplay;
    [SerializeField] private GameObject dialougePanel;

    [Header("Animations & Sounds")]
    [SerializeField] private Animator dialougeAnimator;
    [SerializeField] private AudioSource creepyLaughAudioSource;

    private void Start()
    {
        Invoke("StartDialogueSystem", 0.4f);
    }

    void StartDialogueSystem()
    {
        dialougePanel.SetActive(true);

        sentences = new Queue<string>();
        if(SceneManager.GetActiveScene().name == "MainGame") Invoke("AlterIsGamePaused", pauseTime);

        if (dialougeAnimator != null) dialougeAnimator.SetBool("hasDialougeStarted", true);
        if (player != null) StartDialouge(player);
        else StartDialouge(unknown);
    }

    void AlterIsGamePaused()
    {
        if (FindObjectOfType<GameManager>() == null) return;

        if (FindObjectOfType<GameManager>().isGamePaused)
        {
            FindObjectOfType<GameManager>().isGamePaused = false;
        }
        else
        {
            FindObjectOfType<GameManager>().isGamePaused = true;
        }
    }

    public void StartDialouge(DialougeSO dialougeHolder)
    {
        if (dialougeHolder == null) return;

        canDoNextDialouge = false;

        if(FindObjectOfType<PlayerAttack>() != null) FindObjectOfType<PlayerAttack>().canShoot = false;
        
        currentDialougeHolder = dialougeHolder;

        sentences.Clear();

        speakerDisplay.text = dialougeHolder.speaker;

        foreach (string sentence in dialougeHolder.sentences)
        {
            sentences.Enqueue(sentence);
        }

        canDoNextDialouge = true;
        DisplayNextSentence();

    }

    public void PlayNextButtonSound()
    {
        GetComponentInChildren<AudioSource>().Play();
    }

    public void DisplayNextSentence()
    {
        if (canDoNextDialouge)
        {
            if (sentences.Count == 0)
            {
                EndDialouge();
                return;
            }

            string sentence = sentences.Dequeue();

            // This works for two different scenes with different sentences with different sounds
            if (sentence.StartsWith("BTW") || sentence.StartsWith("Now,") || sentence.StartsWith("I don't"))
            {
                creepyLaughAudioSource.Play();
            }

            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        canDoNextDialouge = false;
        dialougeDisplay.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeDisplay.text += letter;

            GetComponent<AudioSource>().Play();
            yield return null;
        }
        canDoNextDialouge = true;
    }

    void EndDialouge()
    {
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            Debug.Log("Quit");
            Application.Quit();
            return;
        }

        if (currentDialougeHolder.speaker == player.speaker)
        {
            StartDialouge(unknown);
        }
        else if(currentDialougeHolder.speaker == unknown.speaker)
        { 

            if (dialougeAnimator != null)
            {
                dialougeAnimator.SetBool("hasDialougeStarted", false);

                FindObjectOfType<PlayerAttack>().canShoot = true;
                AlterIsGamePaused();
            }
        }
    }
}
