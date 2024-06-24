using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Target; //ī�޶� ����ٴ� Ÿ��

    public float offsetX = 0.0f; //ī�޶��� x��ǥ
    public float offsetY = 2.0f; //ī�޶��� y��ǥ
    public float offsetZ = -1.5f; //ī�޶��� z��ǥ

    public float CameraSpeed = 10.0f;
    Vector3 TargetPos;

    public float angleX = 40.0f;
    public float angleY = 0.0f;
    public float angleZ = 0.0f;

    void FixedUpdate()
    {
        //Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3
        (
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
        );

        //ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        //ī�޶��� ���� ����
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }
}
