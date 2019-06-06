using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }

    private string _npcName;
    private List<string> dialogueLines;

    public GameObject dialoguePanel;
    private Button _continueButton;
    private Text _dialogueText;
    private Text _nameNpcText;
    private int _dialogueId;

    void Awake()
    {
        _continueButton = dialoguePanel.transform.Find("Button").GetComponent<Button>();
        _dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        _nameNpcText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        _continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        _dialogueId = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        _npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        _dialogueText.text = dialogueLines[_dialogueId];
        _nameNpcText.text = _npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if(_dialogueId < dialogueLines.Count - 1)
        {
            _dialogueId++;
            _dialogueText.text = dialogueLines[_dialogueId];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
