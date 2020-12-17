using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToParent : MonoBehaviour
{
    public GameObject TheParent;
    private PolygonCollider2D CollisionReInitiate;
    private OctagonShoot OctagonRef;

    private void Start()
    {
        CollisionReInitiate = TheParent.GetComponent<PolygonCollider2D>();
        //OctagonRef = TheParent.GetComponent<OctagonShoot>();
        //OctagonRef.OnDeadOctagon += ReturnToTheParent;
    }

    /*public void ReturnToTheParent() {
        transform.position = new Vector3(TheParent.transform.position.x + 0.5f, TheParent.transform.position.y, 0f);
        transform.rotation = Quaternion.identity;
        transform.SetParent(TheParent.transform);
    }*/

    private void OnTransformParentChanged()
    {       
        CollisionReInitiate.enabled = false;
        CollisionReInitiate.enabled = true;
    }
}
