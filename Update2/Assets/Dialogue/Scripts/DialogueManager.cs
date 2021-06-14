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
    bool next_clicked = false;
    bool talk_clicked = false;

    public GameObject player;
    public GameObject dialogueUI;
    public GameObject sel_start;
    public GameObject sel;

    public Button next;  

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    private Vector3 old;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        sel_start.SetActive(false);
        sel.SetActive(false);
        old = transform.eulerAngles;
    }
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 4f && isTalking == false)
        {
            transform.LookAt(player.transform);
            sel_start.SetActive(true);
        }
        else if (distance <= 4f)
        {
            transform.LookAt(player.transform);
            sel_start.SetActive(false);
        }
        else
        {
            transform.eulerAngles = old;
            sel_start.SetActive(false);
        }

        if(isTalking){
            
            if (curResponseTracker != npc.playerDialogue.Length - 1) next.interactable = true;
            else if (isTalking == false) next.interactable = true;
            else next.interactable = false;
            
            if (next_clicked)
            {
                if (curResponseTracker == npc.playerDialogue.Length - 1)
                {
                }
                else if (curResponseTracker == npc.playerDialogue.Length - 2)
                {
                    curResponseTracker = npc.next_response[curQuestionTracker];
                }
                else if (npc.ansto_npc[curResponseTracker + 1] != curQuestionTracker)
                {
                    curResponseTracker = npc.next_response[curQuestionTracker];
                }
                else
                {
                    curResponseTracker++;
                }
                next_clicked = false;
            }

            playerResponse.text = npc.playerDialogue[curResponseTracker];
            if (talk_clicked)
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
                talk_clicked = false;
            }
        }
    }
    public void NextClick()
    {
        next_clicked = true;
    }

    public void TalkClick()
    {
        talk_clicked = true;
    }
    public void StartClick()
    {
        dialogueUI.SetActive(true);
        sel.SetActive(true);
        StartConversation();
    }

    public void StopClick()
    {
        dialogueUI.SetActive(false);
        sel.SetActive(false);
        EndDialogue();
    }
    /*
    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 5.5f)
        {

            if (curResponseTracker != npc.playerDialogue.Length - 1) sign.SetActive(true);
            else if (isTalking == false) sign.SetActive(true);
            else sign.SetActive(false);

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (curResponseTracker == npc.playerDialogue.Length - 1)
                {
                }
                else if (curResponseTracker == npc.playerDialogue.Length - 2)
                {
                    curResponseTracker = npc.next_response[curQuestionTracker];
                }
                else if (npc.ansto_npc[curResponseTracker + 1] != curQuestionTracker)
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
            /
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

        }
        else
        {
            sign.SetActive(false);
            EndDialogue();
        }
    }

    void OnMouseExit()
    {
        //sign.SetActive(false);
        if (isTalking) EndDialogue();
    }
    */
    void StartConversation()
    {
        Debug.Log("talking");
        isTalking = true;
        curQuestionTracker = 0;
        curResponseTracker = 0;
        npcName.text = npc.nametext;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        Debug.Log("stop talking");
        isTalking = false;
    }

}
