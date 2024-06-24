using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�� �������� Scene ��ȯ
    public void Change()
    {
        
        SceneManager.LoadScene("GameScene");
    }

    //���� ����
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    //��ư ���� �� ���� �ٷ� ��ȯ�Ǹ� �Ҹ��� �� ��
    //Invoke�� �̿��� �Լ� ������ �����Ͽ� �Ҹ��� ���� ��ȯ�ǰ� ��
    public void SceneChange()
    {
        //Invoke("�����Լ�", �����ð�);
        //Change �Լ��� 0.5�� �ڿ� ����
        Invoke("Change", 0.5f);
    }

    //���� ����
    public void SceneExit()
    {
        Invoke("Exit", 0.5f);
    }
}
