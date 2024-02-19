using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NPC_Dialogue : MonoBehaviour
{
    // Range of collider dialogue to active
    public float dialogueRange;

    // Create Layer of player
    public LayerMask playerLayer;

    bool PlayerHit;
    public DialogueSetting dialogue;

    public GameObject textInstruction;

    private List<string> sentences = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetNPCDialogue();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }


    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && PlayerHit)
        {   


            if(sentences != null)
            {
                DialogueControl.instance.Speech(sentences.ToArray());
            }
      
            if(DialogueControl.instance.GetIndex() < sentences.ToArray().Length)
            {
                DialogueControl.instance.NextSentence();
            }
            
        }
    }


    void GetNPCDialogue()
    {
        for(int i =0; i < dialogue.dialogues.Count; i++)
        {
            switch(DialogueControl.instance.languange)
            {
                case DialogueControl.idioma.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idioma.en:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
            }
        }
    }

    // Create a circle colider2 with params. The hit show will be true if the colider with the layer inform in params
    // The method has 3 param (The initial position of circle, the Range in float and the mask to actived the HIT)
    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null)
        {   
          
            PlayerHit = true;
            textInstruction.SetActive(PlayerHit);
        }else{

             PlayerHit = false;
             textInstruction.SetActive(PlayerHit);
            //  DialogueControl.instance.dialogueObj.SetActive(false);
             DialogueControl.instance.CloseDialogueHUD();
        }
    }


    // Cria um circulo visualmente para ver o range da ativação do dialogo no método ShowDialogue()  / Create a visual circle to show the range of activeted methods ShowDialogue() 
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
        
    }
}
