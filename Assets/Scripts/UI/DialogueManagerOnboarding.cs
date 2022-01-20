using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerOnboarding : MonoBehaviour {
    public TextMeshProUGUI beeText;

    [SerializeField]
    private List<string> sentences;
    [SerializeField]
    private List<AudioClip> voiceOverSentences;

    private int sentenceIndex = 0;

    private int amountOfSecondsTillNext = 10;
    private float timer = 0.0f;
    private int timerInSeconds = 0;
    private int amountOfMSInASecond = 60;
    private bool counting = false;
    private int zero = 0;

    [SerializeField]
    private GameObject Controller, Button, Bob, Carousel;

    [SerializeField]
    private GameObject vrRig;

    private AudioSource audio;

    bool pushedOnce = false;

    void Awake() {
        sentences = new List<string>();
        audio = vrRig.GetComponent<AudioSource>();
    }

    void Update() {
        if(sentenceIndex == 1 || sentenceIndex == 2 || sentenceIndex == 3) {
            counting = true;
        }

        if(counting) {
            TimerCheck();
        }

    }

    public void StartBeeText(Dialogue dialogue) {
        if(pushedOnce == false) {
            pushedOnce = true;
            sentences.Clear();

            foreach(string sentence in dialogue.sentences) {
                sentences.Add(sentence);
            }

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence() {
        if(sentenceIndex > sentences.Count) {
            EndDialogue();
            return;
        }

        if(sentenceIndex == 2) {
            Controller.SetActive(true);
        }

        if(sentenceIndex == 3) {
            Controller.SetActive(false);
            Button.SetActive(true);
        }

        if(sentenceIndex == 5) {
            Bob.SetActive(true);
            Controller.SetActive(false);
        }

        if(sentenceIndex == 7) {
            Carousel.SetActive(true);
        }

        Debug.Log(sentenceIndex);
        string sentence = sentences[sentenceIndex];
        beeText.text = sentence;
        AudioClip clip = voiceOverSentences[sentenceIndex];
        audio.clip = clip;
        audio.Play();
        sentenceIndex++;

    }

    public void TimerCheck() {
        timer += Time.deltaTime;
        timerInSeconds = (int) timer % amountOfMSInASecond;

        if(timerInSeconds >= amountOfSecondsTillNext) {
            ResetTimer();
            DisplayNextSentence();
        }
    }

    private void ResetTimer() {
        counting = false;
        timer = zero;
        timerInSeconds = zero;
    }

    void EndDialogue() {
        Debug.Log("end");
    }
}