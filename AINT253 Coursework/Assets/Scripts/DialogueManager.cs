using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public Text nameText;
    public Text dialogueText;

    public GameObject textManager;
    public GameObject intercom;

    private Queue<string> sentences;

    private Animator textManagerAnim;

    private AudioSource textAudio;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        textManagerAnim = textManager.GetComponent<Animator>();
        textAudio = intercom.GetComponent<AudioSource>();

        textManagerAnim.SetBool("isOpen", false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //nameText.text = dialogue.name;

        sentences.Clear();

        textManagerAnim.SetBool("isOpen", true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Invoke("EndDialogue", 2.5f);
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        Invoke("DisplayNextSentence", 2.5f);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            if (!textAudio.isPlaying)
            {
                textAudio.Play();
            }
            yield return null;
        }
    }

    void EndDialogue()
    {
        textManagerAnim.SetBool("isOpen", false);
    }
}
