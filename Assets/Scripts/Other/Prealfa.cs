using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prealfa : MonoBehaviour {
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 1f;
    public float CharacterRateMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.X;

    private bool _isDialoguePlaying = false;
    public GameObject Blink;
    public bool PodePassar;

    public string Proximacena;
    // Use this for initialization
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
        PodePassar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDialoguePlaying)
        {
            _isDialoguePlaying = true; 
            StartCoroutine(StartDialogue());
        }
            
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength)
        {
            yield return StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex]));
            currentDialogueIndex++;
            
        }
        _isDialoguePlaying = false;
       
    }
    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;
            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                  
                }
            }
            else
            {
                break;
                
            }
        }
        while (true)
        {
            Cliquei();
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
                
            }
            PodePassar = true;
            if(PodePassar == true)
            {
                Blink.SetActive(true);
            }
            print(PodePassar);
            
            yield return 0;
        }
        _textComponent.text = "";
        
;
    }
    void Cliquei()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(Proximacena);
        }
    }
}
