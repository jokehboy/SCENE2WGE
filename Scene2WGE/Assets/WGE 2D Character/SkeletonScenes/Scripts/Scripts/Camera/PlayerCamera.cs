using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    protected Transform target;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    [SerializeField]
     float zOffset;

    [SerializeField]
    Transform reference;

    [SerializeField]
    List<Transform> lanes;

    [SerializeField]
    protected float followSpeed = 4f;



    [SerializeField]
    public float zoomFactor = 1f;

    [SerializeField]
    float zoomSpeed = 3f;

    private float originalSize = 0f;

    private Camera thisCamera;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }


    public Transform TrackingTarget
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

   
    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
    
    // Update is called once per frame
    void Update()
    {
        float targetSize = originalSize * zoomFactor;
        if(targetSize!= thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }

        float xTarget = target.position.x + xOffset;
        float yTarget = target.position.y + yOffset;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
