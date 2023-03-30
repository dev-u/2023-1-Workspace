using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region SETUP

    [SerializeField] private GameObject parentTextPanel;
    [SerializeField] private TextMeshProUGUI mainText;

    [SerializeField] 
    private GameObject choicesParent;
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    #endregion

    #region INK RELATED

    private Story currentStory;

    #endregion
    private void Setup()
    {
        var lenght = choicesParent.transform.childCount;
        choices = new GameObject[lenght];
        choicesText = new TextMeshProUGUI[lenght];

        for (int i = 0; i < lenght; i++)
        {
            choices[i] = choicesParent.transform.GetChild(i).gameObject;
            choicesText[i] = choices[i].GetComponentInChildren<TextMeshProUGUI>();
            choices[i].SetActive(false);
        }

        parentTextPanel.SetActive(true);

    }
    public void OpenDialogue(TextAsset inkAsset)
    {
        Setup();
        currentStory = new Story(inkAsset.text);
        currentStory.BindExternalFunction("TriggerAlgo", () => MyDebugLog());
        DisplayNextMessage();

    }

    public void DisplayNextMessage()
    {
        if (!currentStory.canContinue)
        {
            EndDialogue();
            return;
        }

        mainText.text = currentStory.Continue();
        DisplayChoices();
        HandleTags(currentStory.currentTags);

    }

    private void DisplayChoices()
    {
        List<Choice> choices = currentStory.currentChoices;
        if (choices.Count == 0)
            return;

        for (int i = 0; i < choices.Count; i++)
        {
            this.choices[i].SetActive(true);
            choicesText[i].text = choices[i].text;
        }

    }
    public void MakeChoice(int index)
    {
        currentStory.ChooseChoiceIndex(index);
        foreach(var go in choices)
            go.SetActive(false);

        DisplayNextMessage();

    }
    private void HandleTags(List<string> tags)
    {
        foreach (var tag in tags)
        {
            string[] split = tag.Split(":");
            var tagKey = split[0].Trim();
            var tagValue = split[1].Trim();


            switch (tagKey)
            {
                case "author":
                    Debug.Log(tagValue);
                    break;
                case "date":
                    Debug.Log(tagValue);
                    break;
            }

        }

    }
    private void EndDialogue()
    {
        parentTextPanel.SetActive(false);
    }

    private void MyDebugLog()
    {
        var playerHasKey = false;
        if (playerHasKey)
            return;
        else
            return;
    }

}
