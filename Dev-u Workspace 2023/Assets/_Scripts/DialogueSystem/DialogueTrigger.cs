using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkAsset;
    public void TriggerDialgogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(inkAsset);
    }
}
