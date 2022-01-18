using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public TextMeshProUGUI beeText;

    [SerializeField]
    private List<string> sentences;

    private int sentenceIndex = 0;

    bool pushedOnce = false;

    void Awake() {
        sentences = new List<string>();
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

    void EndDialogue() {
        Debug.Log("end");
    }
}