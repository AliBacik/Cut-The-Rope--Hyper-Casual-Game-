using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public float ZincirIleOlanMesafe=0.2f;

    public Dictionary<string, HingeJoint2D> HingeControl = new Dictionary<string, HingeJoint2D>();
    public void SonZincirBagla(Rigidbody2D SonZincir, string HingeAdi)
    {

        HingeJoint2D joint =gameObject.AddComponent<HingeJoint2D>();
        HingeControl.Add(HingeAdi,joint);
        joint.autoConfigureConnectedAnchor=false;
        joint.connectedBody=SonZincir;
        joint.anchor=Vector2.zero;
        joint.connectedAnchor=new Vector2(0f,-ZincirIleOlanMesafe);

    }
}
