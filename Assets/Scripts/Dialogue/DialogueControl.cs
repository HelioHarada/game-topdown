using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idioma{
        pt,en
    }   

    public idioma languange;

    [Header("Components")]
    public GameObject dialogueObj; // Janela do Dialogo - Window dialogue
    public Image profileSprite; // Sprite 
    public Text speechText; // Texto da fala / Speech text
    public Text ActorName; // nome do NPC / NPC name
    

    [Header("Settings")]
    public float typingSpeed; // Velocidade da fala

    // Variaveis de controle/ control variables
    private bool isShowing; // Se a janela está visivel - if window is opened
    private int index; // Interação total de texto  - interation of total text speech
    
    public int GetIndex(){
        return index;
    }

    private string[] sentences;

    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //  Pular para proxima fala / Next to next speech
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length -1)
            {   
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }else{
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;
            }
        }
    }



    // chamar a fala / call speech
    public void Speech(string[] txt)
    {
        if(!IsShowing)
        {
            dialogueObj.SetActive(true);
            
            sentences = txt;

            StartCoroutine(TypeSentence());
            IsShowing = true;

        }
    }

    public void CloseDialogueHUD(){
            speechText.text = "";
            index = 0;
            dialogueObj.SetActive(false);
            sentences = null;
            IsShowing = false;
    }
}
