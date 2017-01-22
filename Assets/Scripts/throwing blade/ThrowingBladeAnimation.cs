using UnityEngine;
using System.Collections;

public class ThrowingBladeAnimation : MonoBehaviour {

    //public PlatformerMotor2D parentMotor;
    private bool facingLeft;
    public GameObject visualChild;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (parentMotor.velocity.x <= -0.1f)
        //{
        //    facingLeft = true;
        //}
        //else if (parentMotor.velocity.x >= 0.1f)
        //{
        //    facingLeft = false;
        //}

        Vector3 rotateDir = /*facingLeft ? Vector3.forward :*/ Vector3.back;
        visualChild.transform.Rotate(rotateDir, rotationSpeed * Time.deltaTime);
	}
}
