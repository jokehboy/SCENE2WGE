using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.EventSystems;


public class DialougeManager : MonoBehaviour
{
    public List<NodeData> TheNodes = new List<NodeData>();

    DialougeUI dialougeUI;
    NodeContainer nodeContainer;
    public List<string> PlayerResponse;
    public List<string> PlayerChoice;
    public string NPCText;
    public string option1, option2, option3, option4;
    public int currentNode;
    public int responseSelected;
    public GameObject UI;

    
    void Start()
    {
        PlayerResponse = new List<string>();
        dialougeUI = GameObject.Find("Canvas").GetComponent<DialougeUI>();
        UI.SetActive(false);
    }

    public void ConversationTrigger()
    {
        StartDialouge(TheNodes);
        UI.SetActive(true);
        GameObject.Find("2DPlayerCharacter").GetComponent<PlayerMovement2D>()._mState = MovementState.DISABLED;
        Debug.Log("Conversation Triggered");
    }

    public void StartDialouge(List<NodeData> dialouge)
    {
        PlayerResponse.Clear();
        currentNode = 0;
        dialougeUI.NPCText.text = dialouge[0].NPCText;

        for(int i = 0; i<dialouge[0].responses.Count;i++)
        {
            PlayerResponse.Add(dialouge[0].responses[i]);
            if(i==0)
            {
                option1 = PlayerResponse[0];
                dialougeUI.option1.text= PlayerResponse[0];
            }
            else
            { option1 = null; }
            if(i==1)
            {
               option2 = PlayerResponse[1];
               dialougeUI.option2.text = PlayerResponse[1];
            }
            else
            { option2 = null; }
            if (i == 2)
            {
                option3 = PlayerResponse[2];
                dialougeUI.option3.text = PlayerResponse[2];
            }
            else
            { option3 = null; }
        }

    }


    public void CurrentConversationText(int NodeID, List<NodeData> dialouge)
    {
        dialougeUI.option1.text = "";
        dialougeUI.option2.text = "";
        dialougeUI.option3.text = "";
        PlayerResponse.Clear();
        dialougeUI.NPCText.text = dialouge[NodeID].NPCText;

        for(int i = 0; i<dialouge[NodeID].responses.Count;i++)
        {
            if(i==0 && i < dialouge[NodeID].responses.Count + 1)
            {
                if(dialouge[NodeID].responses[i] == null)
                {
                    dialougeUI.option1.text = " ";
                }
                else
                {
                    dialougeUI.option1.text = dialouge[NodeID].responses[i];

                }
            }
            

            if (i == 1 && i < dialouge[NodeID].responses.Count + 1)
            {
                if (dialouge[NodeID].responses[i] == null)
                {
                    dialougeUI.option2.text = " ";
                }
                else
                {
                    dialougeUI.option2.text = dialouge[NodeID].responses[i];

                }
            }

            if (i == 2 && i < dialouge[NodeID].responses.Count + 1)
            {
                if (dialouge[NodeID].responses[i] == null)
                {
                    dialougeUI.option3.text = " ";
                }
                else
                {
                    dialougeUI.option3.text = dialouge[NodeID].responses[i];

                }
            }
        }

        CheckEnd(currentNode);
    }


     void Update()
    {
        
        
    }



    public void ResponseChosen(int response)
    {

        ChangeDialouge(response, TheNodes);
    }

    public void ChangeDialouge(int response, List<NodeData> dialouge)
    {
        currentNode = dialouge[currentNode].responseDestinationNodeID[response];
        CurrentConversationText(currentNode, TheNodes);
    }


    public void CheckEnd(int NodeID)
    {
        if(NodeID == 4)
        {
            EndDialouge();
            return;
        }
    }
    void EndDialouge()
    {
        UI.SetActive(false);
        GameObject.Find("2DPlayerCharacter").GetComponent<PlayerMovement2D>()._mState = MovementState.ON_GROUND;

    }



}

