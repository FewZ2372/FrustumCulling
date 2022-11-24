using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frustrum : MonoBehaviour
{
    [SerializeField] private Transform nearBottomRight;
    [SerializeField] private Transform nearBottomLeft;
    [SerializeField] private Transform nearUpLeft;
    [SerializeField] private Transform nearUpRight;
    [SerializeField] private Transform farBottomRight;
    [SerializeField] private Transform farUpLeft;
    [SerializeField] private Transform farUpRight;
    [SerializeField] private Transform farBottomLeft;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per framete 
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(nearBottomLeft.position, farBottomLeft.position);
        Gizmos.DrawLine(farBottomLeft.position, farUpLeft.position);
        Gizmos.DrawLine(farUpLeft.position, farUpRight.position);
        Gizmos.DrawLine(farBottomRight.position, nearBottomRight.position);
        Gizmos.DrawLine(nearBottomRight.position, nearUpRight.position);
        Gizmos.DrawLine(nearUpRight.position, farUpRight.position);
        Gizmos.DrawLine(nearUpLeft.position, farUpLeft.position);
        Gizmos.DrawLine(nearUpRight.position, nearUpLeft.position);
        Gizmos.DrawLine(farUpRight.position, farBottomRight.position);
        Gizmos.DrawLine(farBottomRight.position, farBottomLeft.position);
        Gizmos.DrawLine(nearUpLeft.position, nearBottomLeft.position);
        Gizmos.DrawLine(nearBottomLeft.position, nearBottomRight.position);

    }

    public Vector3[] getPos()
    {
        return new Vector3[]{ nearBottomRight.position, nearBottomLeft.position,
                              nearUpLeft.position, nearUpRight.position,
                              farBottomRight.position, farUpLeft.position,
                              farUpRight.position, farBottomLeft.position };
    }


}
