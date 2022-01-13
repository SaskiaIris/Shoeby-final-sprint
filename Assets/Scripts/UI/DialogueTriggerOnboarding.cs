using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOnboarding : MonoBehaviour
{

    public Dialogue dialogue;

    void Start()
    {
        FindObjectOfType<DialogueManagerOnboarding>().StartBeeText(dialogue);
    }

}
