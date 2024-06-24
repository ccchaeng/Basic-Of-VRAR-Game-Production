using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform camPivot;
    public float rotationSpeed = 0.4f;

    Vector3 beginPos; //드래그 시작할 때 스크린의 좌표
    Vector3 draggingPos; //드래그 중인 스크린의 좌표
    
    //드래기를 하기 전후의 camPivot의 rotation값 저장할 Angle변수들
    float xAngle;
    float yAngle;

    //드래그를 시작할 때의 camPivot의 rotation값을 저장할 AngleTemp 변수들
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
        
        //아래로 드래깅 할때는 xAngle이 그만큼 감소해야 하고
        //오른쪽으로 드래깅 할때는 yAngle이 그만큼 증가해야 함
        //디바이스 크기 변화에 대응하기 위해 변화량을 Screen.width, Screen.height로 나눠줌
        yAngle = yAngleTemp + (draggingPos.x - beginPos.x) * Screen.height / 1080 * rotationSpeed * Time.deltaTime;
        xAngle = xAngleTemp - (draggingPos.y - beginPos.y) * Screen.width / 1920 * rotationSpeed * Time.deltaTime;

        //xAngle의 최대 최소값
        //if (xAngle > 30) xAngle = 30;
        //if (xAngle < -60) xAngle = -60;

        //Euler 각을 Quaternion으로 변환하여 camPivot.rotation 값에 대입
        camPivot.rotation = Quaternion.Euler(xAngle, yAngle, 0.0f);
    }
}