using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text beeText;

    [SerializeField]
    private Queue<string> sentences;

    bool pushedOnce = false;



    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartBeeText (Dialogue dialogue)
    {

        if (pushedOnce == false)
        {
            pushedOnce = true;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        

        string sentence = sentences.Dequeue();
        beeText.text = sentence;
            
    }

    void EndDialogue()
    {
        Debug.Log("end");
    }

}
