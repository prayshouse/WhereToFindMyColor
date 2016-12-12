using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public Vector3 mPosition;

    private GameObject mBall;
    private Vector3 mDirection;
    private GameObject mCamera;
    private bool mGrounded;
    //private float mGravity;

    private Rigidbody mRigidbody;

    private void Awake()
    {
        moveSpeed = 0.4f;
        jumpSpeed = 8.0f;
        mGrounded = true;
        //mGravity = 20.0f;
    }

    void Start ()
    {
        mDirection = new Vector3(1.0f, 0.0f, 0.0f);
        mBall = gameObject;
        mPosition = mBall.transform.position;
        mCamera = GameObject.Find("Main Camera");
        mRigidbody = mBall.GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        mDirection = mCamera.GetComponent<FirstView>().direction;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if (Input.GetKey(KeyCode.W))
        {
            mPosition = transform.position + mDirection * moveSpeed;
            mBall.transform.position = mPosition;
        }
        if (Input.GetKey(KeyCode.S))
        {
            mPosition = transform.position - mDirection * moveSpeed;
            mBall.transform.position = mPosition;
        }
        if (Input.GetKey(KeyCode.A))
        {
            mPosition = transform.position + new Vector3(-mDirection.z, 0.0f, mDirection.x) * moveSpeed;
            mBall.transform.position = mPosition;
        }
        if (Input.GetKey(KeyCode.D))
        {
            mPosition = transform.position + new Vector3(mDirection.z, 0.0f, -mDirection.x) * moveSpeed;
            mBall.transform.position = mPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

	}

    void jump()
    {
        if (mGrounded == true)
        {
            print("jump mGround:true -> false");
            mRigidbody.AddForce(Vector3.up * jumpSpeed);
            mRigidbody.velocity = new Vector3(0.0f, 15.0f, 0.0f);
            mGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("fall mGround:false -> ture");
        mGrounded = true;
    }
}
