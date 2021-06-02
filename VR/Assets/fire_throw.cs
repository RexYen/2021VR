using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(LineRenderer))]
public class fire_throw : MonoBehaviour
{
    XRGrabInteractable m_GrabInteractable;
    //MeshRenderer m_MeshRenderer;

    static Color s_UnityMagenta = new Color(0.929f, 0.094f, 0.278f);

    bool m_Held;
    public GameObject ThrowInteractor;

    private LineRenderer line;
    // Initial trajectory velocity
    Transform startTransform;
    private Vector3 startPosition;
    private Vector3 startVelocity;
    // Step distance for the trajectory
    [SerializeField]
    private float trajectoryVertDist;
    // Max length of the trajectory
    [SerializeField]
    private float maxCurveLength;
    [SerializeField]
    private float speed;
    public GameObject van;
    private void Awake()
    {
        // Get line renderer reference
        line = GetComponent<LineRenderer>();
        Invoke("Destroy", 8);

    }
    protected void OnEnable()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        ThrowInteractor = GameObject.Find("RightBaseController");
        startTransform = ThrowInteractor.transform;

        m_GrabInteractable.firstHoverEntered.AddListener(OnFirstHoverEntered);
        m_GrabInteractable.lastHoverExited.AddListener(OnLastHoverExited);
        m_GrabInteractable.selectEntered.AddListener(OnSelectEntered);
        m_GrabInteractable.selectExited.AddListener(OnSelectExited);
    }
    protected void OnDisable()
    {
        m_GrabInteractable.firstHoverEntered.RemoveListener(OnFirstHoverEntered);
        m_GrabInteractable.lastHoverExited.RemoveListener(OnLastHoverExited);
        m_GrabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        m_GrabInteractable.selectExited.RemoveListener(OnSelectExited);
    }

    protected virtual void OnSelectEntered(SelectEnterEventArgs args)
    {
        m_Held = true;
    }

    private void Update()
    {
        if (m_Held)
        {
            //timer = timer + Time.deltaTime;
            DrawCurve();
            CancelInvoke("Destroy");
            Invoke("vanish",6);
        }

        

 
    }
    private void vanish(){
        Instantiate(van,transform .position,transform .rotation);
        Destroy(gameObject);

    }
    private void Destroy(){

        Destroy(gameObject);

    }
    
    protected virtual void OnSelectExited(SelectExitEventArgs args)//throw
    {
        line.positionCount = 0;
        CancelInvoke("vanish");
        this.gameObject.GetComponent<Rigidbody>().velocity = startTransform.forward*speed;
    }
    /*
    private Vector3 BallisticVel2(Transform origin, Vector3 direction, float angle)
    {
        //Vector3 direction = destination.position - origin.position;
        float height = origin.position.y * 5;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += height / Mathf.Tan(a);
        if (distance < 0.0) distance = -1 * distance;
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }
    */
    private void DrawCurve()
    {
        // Create a list of trajectory points
        var curvePoints = new List<Vector3>();
        startPosition = startTransform.position;
        curvePoints.Add(startPosition);
        // Initial values for trajectory
        var currentPosition = startPosition;
        var currentVelocity = startTransform.forward*speed;
        currentVelocity += new Vector3(0, (float)-9.8, 0) * Time.fixedDeltaTime;
        // Init physics variables
        RaycastHit hit;
        Ray ray = new Ray(currentPosition, currentVelocity.normalized);
        float t = Time.fixedDeltaTime;
        // Loop until hit something or distance is too great
        while (!Physics.Raycast(ray, out hit, trajectoryVertDist) && Vector3.Distance(startPosition, currentPosition) < maxCurveLength)
        {
            // Time to travel distance of trajectoryVertDist
            //var t = trajectoryVertDist / currentVelocity.magnitude;
            // Update position and velocity
            //currentVelocity = currentVelocity + t * Physics.gravity;
            //currentPosition = currentPosition + t * currentVelocity;
            currentVelocity = currentVelocity + t * new Vector3(0, (float)-9.8, 0);
            currentPosition = currentPosition + t * currentVelocity;
            // Add point to the trajectory
            curvePoints.Add(currentPosition);
            // Create new ray
            ray = new Ray(currentPosition, currentVelocity.normalized);
        }
        // If something was hit, add last point there
        if (hit.transform)
        {
            curvePoints.Add(hit.point);
        }
        // Display line with all points
        line.positionCount = curvePoints.Count;
        line.SetPositions(curvePoints.ToArray());
    }

    protected virtual void OnLastHoverExited(HoverExitEventArgs args)
    {
        if (!m_Held)
        {
        }
    }

    protected virtual void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        if (!m_Held)
        {
        }
    }
}
