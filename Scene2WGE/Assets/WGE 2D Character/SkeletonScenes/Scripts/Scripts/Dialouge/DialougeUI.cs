using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeUI : MonoBehaviour
{
    public GameObject dialougeManager;
    DialougeManager managerScript;

    public Text NPCText;


    public Button button1;
    public Text option1;

    public Button button2;
    public Text option2;

    public Button button3;
    public Text option3;

     void Start()
    {
        dialougeManager = GameObject.Find("DialougeManager");
        managerScript = dialougeManager.GetComponent<DialougeManager>();
    }


    public void ChoiceOneSelected()
    {
        managerScript.ResponseChosen(0);
    }
    public void ChoiceTwoSelected()
    {
        managerScript.ResponseChosen(1);
    }
    public void ChoiceThreeSelected()
    {
        managerScript.ResponseChosen(2);

    }
}
    
