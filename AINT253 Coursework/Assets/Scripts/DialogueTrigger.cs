using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{ 
    public Dialogue dialogue;

    private bool hasTriggered = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public static void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player" && !hasTriggered)
        {
            hasTriggered = true;
            TriggerDialogue();
        }
    }
}
