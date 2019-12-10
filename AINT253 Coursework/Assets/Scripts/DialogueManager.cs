using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static bool isPlaying = false;

    //public Text nameText;
    public Text dialogueText;

    public GameObject textManager;
    public GameObject intercom;
    public GameObject intercomRot;

    private Queue<string> sentences;

    private Animator textManagerAnim;
    private Animator intercomAnim;

    private AudioSource textAudio;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        textManagerAnim = textManager.GetComponent<Animator>();
        intercomAnim = intercomRot.GetComponent<Animator>();

        textAudio = intercom.GetComponent<AudioSource>();

        textManagerAnim.SetBool("isOpen", false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //nameText.text = dialogue.name;
        isPlaying = true;

        sentences.Clear();

        textManagerAnim.SetBool("isOpen", true);
        intercomAnim.SetBool("isOn", true);

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
        intercomAnim.SetBool("isOn", false);
        isPlaying = false;
    }
}
