using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Collider))]
public class PaintTrail : MonoBehaviour
{
    Collider col;
    public Transform cursor;
    public float raycastDistance = 2f;
    public float focalPointDistance = 1f;

    public Transform lineRendererToSpawn;

    private LineRenderer current = null;

    public float bufferDistance = 0.1f;
    private Vector3 lastDistance = Vector3.zero;

    public RenderTexture rt;

    private void Awake()
    {
        col = GetComponent<Collider>();
        lineRendererToSpawn.rotation = transform.rotation * Quaternion.Euler(90, 0, 0);
    }

    private void Update()
    {
        RaycastHit rch;

        if (col.Raycast(new Ray(cursor.position, cursor.forward), out rch, raycastDistance))
        {
            float strength = Mathf.Clamp01(1.0f - Mathf.Max(rch.distance - focalPointDistance, 0) / (raycastDistance - focalPointDistance));

            Vector3 colPos = lineRendererToSpawn.InverseTransformPoint(rch.point + strength * rch.normal);

            if (current == null)
            {
                current = Instantiate(lineRendererToSpawn).GetComponentInChildren<LineRenderer>(true);
                current.positionCount = 1;
                current.SetPosition(0, colPos);
                lastDistance = rch.point;
            }
            else if ((rch.point - lastDistance).magnitude > bufferDistance)
            {
                current.positionCount += 1;
                current.SetPosition(current.positionCount - 1, colPos);
                lastDistance = rch.point;
            }
        }
        else
        {
            current = null;
        }
    }
}
