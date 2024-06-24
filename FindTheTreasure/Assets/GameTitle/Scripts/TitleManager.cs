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

    //인 게임으로 Scene 전환
    public void Change()
    {
        
        SceneManager.LoadScene("GameScene");
    }

    //게임 종료
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    //버튼 누를 때 씬이 바로 전환되면 소리가 안 남
    //Invoke를 이용해 함수 실행을 지연하여 소리가 나고 전환되게 함
    public void SceneChange()
    {
        //Invoke("실행함수", 지연시간);
        //Change 함수를 0.5초 뒤에 실행
        Invoke("Change", 0.5f);
    }

    //위와 동일
    public void SceneExit()
    {
        Invoke("Exit", 0.5f);
    }
}
