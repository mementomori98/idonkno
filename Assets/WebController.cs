using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WebController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip;
    public Transform xrRig;
    private float maxDistance = 10000f;
    private SpringJoint joint;

    private bool startGrapple;
    private bool stopGrapple;

    public InputActionReference webTrigger;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        webTrigger.action.started += HandleTriggerPressed;
        webTrigger.action.canceled += HandleTriggerReleased;
    }

    private void OnDestroy()
    {
        webTrigger.action.started -= HandleTriggerPressed;
        webTrigger.action.canceled -= HandleTriggerReleased;
    }

    void Update()
    {
        if (startGrapple)
        {
            StartGrapple();
            startGrapple = false;
        }
        if (stopGrapple)
        {
            StopGrapple();
            stopGrapple = false;
        }
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = xrRig.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(gunTip.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRenderer.positionCount = 2;
            currentGrapplePosition = xrRig.position;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        lineRenderer.enabled = false;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, currentGrapplePosition);
        lineRenderer.enabled = true;
    }

    private void HandleTriggerPressed(InputAction.CallbackContext c)
    {
        startGrapple = true;
    }

    private void HandleTriggerReleased(InputAction.CallbackContext c)
    {
        stopGrapple = true;
    }
}