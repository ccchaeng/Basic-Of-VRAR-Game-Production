using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Target; //카메라가 따라다닐 타겟

    public float offsetX = 0.0f; //카메라의 x좌표
    public float offsetY = 2.0f; //카메라의 y좌표
    public float offsetZ = -1.5f; //카메라의 z좌표

    public float CameraSpeed = 10.0f;
    Vector3 TargetPos;

    public float angleX = 40.0f;
    public float angleY = 0.0f;
    public float angleZ = 0.0f;

    void FixedUpdate()
    {
        //타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3
        (
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
        );

        //카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        //카메라의 각도 지정
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }
}
