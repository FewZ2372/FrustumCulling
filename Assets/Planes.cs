using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour
{
    private Plane leftPlane;
    private Plane rightPlane;
    private Plane topPlane;
    private Plane bottomPlane;
    private Plane frontPlane;
    private Plane backPlane;

    [SerializeField] private Frustrum frustrum;

    [SerializeField] private GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] posS = frustrum.getPos();

        leftPlane = new Plane(posS[1], posS[7], posS[5]);

        rightPlane = new Plane(posS[0], posS[4], posS[6]);

        topPlane = new Plane(posS[2], posS[3], posS[5]);

        bottomPlane = new Plane(posS[1], posS[0], posS[4]);

        frontPlane = new Plane(posS[1], posS[0], posS[3]);

        backPlane = new Plane(posS[7], posS[4], posS[5]);

        leftPlane.Flip();
        bottomPlane.Flip();
        backPlane.Flip();

        checkAllObj();

        //DrawPlane(posS[1], leftPlane.normal);
        //DrawPlane(posS[0], rightPlane.normal);
        //DrawPlane(posS[2], topPlane.normal);
        //DrawPlane(posS[4], bottomPlane.normal);
        //DrawPlane(posS[3], frontPlane.normal);
        //DrawPlane(posS[7], backPlane.normal);
    }

    public void DrawPlane(Vector3 position, Vector3 normal)
    {
        Vector3 v3;
        if (normal.normalized != Vector3.forward)
            v3 = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude; ;
        var corner0 = position + v3;
        var corner2 = position - v3;
        var q = Quaternion.AngleAxis(90.0f, normal);
        v3 = q * v3;
        var corner1 = position + v3;
        var corner3 = position - v3;
        Debug.DrawLine(corner0, corner2, Color.green);
        Debug.DrawLine(corner1, corner3, Color.green);
        Debug.DrawLine(corner0, corner1, Color.green);
        Debug.DrawLine(corner1, corner2, Color.green);
        Debug.DrawLine(corner2, corner3, Color.green);
        Debug.DrawLine(corner3, corner0, Color.green);
        Debug.DrawRay(position, normal, Color.red);
    }

    public bool isPointInFrustrum(Vector3 point)
    {
        bool isPointInFrustrum = leftPlane.GetSide(point) && rightPlane.GetSide(point) &&
                                 topPlane.GetSide(point) && bottomPlane.GetSide(point) &&
                                 frontPlane.GetSide(point)/* && backPlane.GetSide(point)*/;

        return isPointInFrustrum;
    }

    public void checkAllObj()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            Vector3[] verts = objs[i].GetComponent<MeshFilter>().sharedMesh.vertices;

            bool objInFrustrum = false;

            for (int j = 0; j < verts.Length; j++)
            {
                if (isPointInFrustrum(objs[i].transform.TransformPoint(verts[j])))
                {
                    objInFrustrum = true;
                }
            }

            objs[i].GetComponent<MeshRenderer>().enabled = objInFrustrum;

        }

    }
}
