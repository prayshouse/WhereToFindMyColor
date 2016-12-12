using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstView : MonoBehaviour {

    //方向灵敏度  
    public float sensitivityX = 10.0f;
    public float sensitivityY = 10.0f;

    //上下最大视角(Y视角)  
    public float minimumY = -60.0f;
    public float maximumY = 60.0f;

    float rotationX = 0.0f;
    float rotationY = 0F;
    public Vector3 direction;

    private BallMove mBallMove;

    private void Awake()
    {
        direction = new Vector3(1.0f, 0.0f, 0.0f);
        Cursor.visible = false;
    }

    void Start ()
    {
        GameObject ball = GameObject.Find("Ball");
        mBallMove = ball.GetComponent<BallMove>();

        Rigidbody r = GetComponent<Rigidbody>();
        if (r) r.freezeRotation = true;
        
    }

    void Update()
    {

        //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)  
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        //根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y)  
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value   
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //总体设置一下相机角度  
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        
        direction.z = Mathf.Cos(rotationX * Mathf.Deg2Rad);
        direction.x = Mathf.Sin(rotationX * Mathf.Deg2Rad);
    }
}
