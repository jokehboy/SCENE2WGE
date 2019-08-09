using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralocking : MonoBehaviour
{
    #region Public Fields
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    string nodeTag;

    #endregion

    GameObject theCamera;
    PlayerCamera cameraScript;

    #region Private
    private Transform previousTarget;

    private PlayerCamera trackingBehaviour;

    private bool isLocked = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        trackingBehaviour = mainCamera.GetComponent<PlayerCamera>();
        theCamera = GameObject.Find("Main Camera");
        PlayerCamera cameraScript = theCamera.GetComponent<PlayerCamera>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag== nodeTag && !isLocked)
        {
            isLocked = true;
            PushTarget(other.transform);

            if(other.name == "POI test")
            {
                theCamera.GetComponent<PlayerCamera>().zoomFactor = 0.5f;
            }
            if (other.name == "NPC POI")
            {
                theCamera.GetComponent<PlayerCamera>().zoomFactor = 0.3f;
                DialougeManager dialouge = GameObject.Find("DialougeManager").GetComponent<DialougeManager>();
                dialouge.ConversationTrigger();
            }
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == nodeTag && isLocked)
        {
            isLocked = false;
            PopTarget();
            theCamera.GetComponent<PlayerCamera>().zoomFactor = 1f;
        }
    }



    private void PushTarget(Transform newTarget)
    {
        previousTarget = trackingBehaviour.TrackingTarget;
        trackingBehaviour.TrackingTarget = newTarget;
    }

    private void PopTarget()
    {
        trackingBehaviour.TrackingTarget = previousTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
