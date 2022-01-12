using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public TextMeshProUGUI beeText;

    [SerializeField]
    private List<string> sentences;

    private int sentenceIndex = 0;

    private int amountOfSecondsTillNext = 20;
    private float timer = 0.0f;
    private int timerInSeconds = 0;
    private int amountOfMSInASecond = 60;
    private bool counting = false;
    private int zero = 0;

    bool pushedOnce = false;

    void Awake() {
        sentences = new List<string>();
    }

    void Update()
    {
        if (sentenceIndex == 1 || sentenceIndex == 2)
        {
            counting = true;
        }

        if (counting)
        {
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

        string sentence = sentences[sentenceIndex];
        beeText.text = sentence;
        sentenceIndex++;
        
    }

    public void TimerCheck()
    {
        timer += Time.deltaTime;
        timerInSeconds = (int)timer % amountOfMSInASecond;

        if (timerInSeconds >= amountOfSecondsTillNext)
        {
            ResetTimer();
            DisplayNextSentence();
        }
    }

    private void ResetTimer()
    {
        counting = false;
        timer = zero;
        timerInSeconds = zero;
    }

    void EndDialogue() {
        Debug.Log("end");
    }
}