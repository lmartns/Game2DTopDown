using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //janela de dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto de fala 
    public Text actorNameText; //nomedo npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Variáveis de controle
    private bool isShowing; //se a janela está visível 
    private int index; //index das falas
    private string[] sentences;

    public static DialogueControl instance;


    //awake é chamdo antes de todos os starts na hierarquia de execução de scriptsw
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
        foreach (char letter in sentences[index].ToCharArray()) //ler letra por letra 
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular pra proxima fala
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;//adiciona 1
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando termina os textos 
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
