using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    List<string> dialogues = new List<string>();
    [SerializeField]
    GameObject textgo;
    TMP_Text text;
    int dialogueIndex = 0;

    private void Start()
    {
        text = textgo.GetComponent<TMP_Text>();
        Debug.Log(text);

        text.text = dialogues[dialogueIndex];
        dialogueIndex++;
    }
    public void NextDialogue()
    {
        if(dialogueIndex >= dialogues.Count)
        {
            Destroy(gameObject);
            return;
        }
        text.text = dialogues[dialogueIndex];
        dialogueIndex++;
    }
}
