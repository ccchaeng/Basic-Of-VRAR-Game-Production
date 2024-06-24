using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform camPivot;
    public float rotationSpeed = 0.4f;

    Vector3 beginPos; //�巡�� ������ �� ��ũ���� ��ǥ
    Vector3 draggingPos; //�巡�� ���� ��ũ���� ��ǥ
    
    //�巡�⸦ �ϱ� ������ camPivot�� rotation�� ������ Angle������
    float xAngle;
    float yAngle;

    //�巡�׸� ������ ���� camPivot�� rotation���� ������ AngleTemp ������
    float xAngleTemp;
    float yAngleTemp;

    private void Start()
    {
        xAngle = camPivot.rotation.eulerAngles.x;
        yAngle = camPivot.rotation.eulerAngles.y;
    }

    public void OnBeginDrag(PointerEventData beginPoint)
    {
        beginPos = beginPoint.position;

        xAngleTemp = xAngle;
        yAngleTemp = yAngle;
    }

    public void OnDrag(PointerEventData draggingPoint)
    {
        draggingPos = draggingPoint.position;
        
        //�Ʒ��� �巡�� �Ҷ��� xAngle�� �׸�ŭ �����ؾ� �ϰ�
        //���������� �巡�� �Ҷ��� yAngle�� �׸�ŭ �����ؾ� ��
        //����̽� ũ�� ��ȭ�� �����ϱ� ���� ��ȭ���� Screen.width, Screen.height�� ������
        yAngle = yAngleTemp + (draggingPos.x - beginPos.x) * Screen.height / 1080 * rotationSpeed * Time.deltaTime;
        xAngle = xAngleTemp - (draggingPos.y - beginPos.y) * Screen.width / 1920 * rotationSpeed * Time.deltaTime;

        //xAngle�� �ִ� �ּҰ�
        //if (xAngle > 30) xAngle = 30;
        //if (xAngle < -60) xAngle = -60;

        //Euler ���� Quaternion���� ��ȯ�Ͽ� camPivot.rotation ���� ����
        camPivot.rotation = Quaternion.Euler(xAngle, yAngle, 0.0f);
    }
}