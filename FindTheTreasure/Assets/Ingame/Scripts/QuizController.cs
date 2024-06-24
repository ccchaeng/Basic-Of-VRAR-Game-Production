using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject quiz1;
    public GameObject quiz2;
    public GameObject quiz3;
    public GameObject quiz4;
    public GameObject quiz5;

    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        quiz1.SetActive(false);
        quiz2.SetActive(false);
        quiz3.SetActive(false);
        quiz4.SetActive(false);
        quiz5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            //Ray를 발사하여 클릭한 위치에 있는 오브젝트를 찾음
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Ray가 오브젝트에 충돌했을 때
            if(Physics.Raycast(ray, out hit))
            {
                //충돌한 오브젝트가 Apple이라면
                if (hit.collider.gameObject.CompareTag("Apple"))
                {
                    //Quiz1 이미지를 활성화
                    quiz1.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Banana"))
                {
                    quiz2.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Steak"))
                {
                    quiz3.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Avocado"))
                {
                    quiz4.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Carrot"))
                {
                    quiz5.SetActive(true);
                }
            }
        }
    }

    public void Answer1()
    {
        count++;
        quiz1.SetActive(false);
    }

    public void Answer2()
    {
        count++;
        quiz2.SetActive(false);
    }

    public void Answer3()
    {
        count++;
        quiz3.SetActive(false);
    }

    public void Answer4()
    {
        count++;
        quiz4.SetActive(false);
    }

    public void Answer5()
    {
        count++;
        quiz5.SetActive(false);
    }

    public void Wrong()
    {
        HPManager.hp -= 1;
        if(HPManager.hp <= 0 )
        {
            GameManager.Instance.Die();
        }
    }

}
