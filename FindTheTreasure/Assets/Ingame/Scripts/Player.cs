using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;

    public float speed = 10.0f;
    public float rotateSpeed = 10.0f;

    public Transform PlayerTr; //이동하는 대상을 나타내는 변수
    Animator anim; //Animator 변수

    // Start is called before the first frame update
    void Start()
    {
        PlayerTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        float h = joy.Horizontal;
        float v = joy.Vertical;


        Vector3 dir = new Vector3(h, 0, v);
        if(!(h == 0 && v == 0))
        {
            //이동과 회전을 함께 처리
            transform.position += dir * speed * Time.deltaTime;
            //회전하는 부분
            //현재 회전각(transform.rotation)에서 바라보는 방향(Quaternion.LookRotation(dir))까지 지정한 회전속도로 회전함
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }

        if(v >= 0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else if(v <= -0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else if(h >= 0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else if(h <= -0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsSit", true);
        }
    }
}
