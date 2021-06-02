using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float distance;
    int curQuestionTracker = 0;
    int curResponseTracker = 0;

    //public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;



    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver()
    {
        //distance = Vector3.Distance(player.transform.position, this.transform.position);
        //if (distance <= 5.5f)
        //{
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if(curResponseTracker == npc.playerDialogue.Length - 1)
                { 
                }
                else if (curResponseTracker == npc.playerDialogue.Length - 2)
                {
                    curResponseTracker = npc.next_response[curQuestionTracker];
                }
                else if (npc.ansto_npc[curResponseTracker+1] != curQuestionTracker)
                {
                    curResponseTracker = npc.next_response[curQuestionTracker];
                }
                else
                {
                    curResponseTracker++;
                }
            }

            //trigger dialogue
            if (Input.GetKeyDown(KeyCode.X) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.X) && isTalking == true)
            {
                EndDialogue();
            }
            /*
            if(curResponseTracker == 1)
            {
                playerResponse.text = npc.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            */
            playerResponse.text = npc.playerDialogue[curResponseTracker];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (curResponseTracker != npc.playerDialogue.Length - 1)
                {
                    npcDialogueBox.text = npc.dialogue[curResponseTracker + 1];
                    curQuestionTracker = curResponseTracker + 1;
                    curResponseTracker = npc.next_response[curQuestionTracker];
                    playerResponse.text = npc.playerDialogue[curResponseTracker];
                }
                else
                {
                    StartConversation();
                }                
            }
        //}
        //else
        //{
        //    EndDialogue();
        //}
    }

    void OnMouseExit()
    {
        if(isTalking) EndDialogue();
    }
        void StartConversation()
    {
        Debug.Log("talking");
        isTalking = true;
        curQuestionTracker = 0;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.nametext;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        Debug.Log("stop talking");
        isTalking = false;
        dialogueUI.SetActive(false);
    }

}
