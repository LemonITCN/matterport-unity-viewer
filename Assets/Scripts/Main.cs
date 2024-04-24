using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // 主摄像机
    public Camera mainCamera;
    // 键盘移动速度
    public float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // 在界面上放置前进后退两个按钮
        GameObject go = new GameObject("Forward");
        go.transform.SetParent(this.transform);
        go.transform.localPosition = new Vector3(-0.5f, 0, 0);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        go.GetComponent<MeshRenderer>().material.color = Color.red;
        go.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 按WASD沿当前镜头方向移动
        if (Input.GetKey(KeyCode.W))
        {
            mainCamera.transform.Translate(Vector3.forward * this.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            mainCamera.transform.Translate(Vector3.back * this.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            mainCamera.transform.Translate(Vector3.left * this.moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainCamera.transform.Translate(Vector3.right * this.moveSpeed * Time.deltaTime);
        }
        // 旋转相机
        if (Input.GetKey(KeyCode.Q))
        {
            mainCamera.transform.Rotate(Vector3.up, -1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            mainCamera.transform.Rotate(Vector3.up, 1 * Time.deltaTime);
        }
        // 鼠标拖动旋转相机
        if (Input.GetMouseButton(0))
        {
            mainCamera.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * -1);
        }
        // 也可以使用Input.GetAxis("Mouse Y")来控制相机的俯仰角
        if (Input.GetMouseButton(0))
        {
            mainCamera.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y"));
        }
        // 触摸屏幕旋转相机
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                // 根据触摸调整相机的 X Z 轴旋转角度
                mainCamera.transform.Rotate(Vector3.up, touch.deltaPosition.x * -0.1f);
            }
        }
    }
}
