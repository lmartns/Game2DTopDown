using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;
    // Start is called before the first frame update

    public DialogueSettings dialogue;

    bool playerhit;
    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    //chamdo a cada frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerhit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
            }

            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    // usado pela física
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null) //se o player é diferente de null
        {
            playerhit = true;
        }
        else
        {
            playerhit = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
