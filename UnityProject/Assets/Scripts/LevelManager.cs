using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [Header("是否顯示技能")]
    public bool showRandomSkill;


    [Header("是否自動開門")]
    public bool autoOpenDoor;

    [Header("隨機技能介面")]
    public GameObject randomSkill;

    private Animator door;  //門
    private Image cross;    //轉場畫面

    private void Start()
    {
        door = GameObject.Find("門").GetComponent<Animator>();
        cross = GameObject.Find("轉場畫面").GetComponent<Image>();

        if (autoOpenDoor) Invoke("OpenDoor", 6);
        if (showRandomSkill) ShowRandomSkill();
    }

    /// <summary>
    /// 顯示隨機技能介面
    /// </summary>
    private void ShowRandomSkill()
    {
        randomSkill.SetActive(true);
    }

    /// <summary>
    /// 播放開門動畫
    /// </summary>
    private void OpenDoor()
    {
        door.SetTrigger("開門");
    }

    /// <summary>
    /// 載入關卡
    /// </summary>
    private IEnumerator LoadLevel()
    {

        AsyncOperation ao = SceneManager.LoadSceneAsync("關卡2");        //場景資訊 = 取得載入場景("場景名稱")
        ao.allowSceneActivation = false;                                 //載入場景資訊.是否允許切換 = 否

        while (!ao.isDone)                                               //當(當在入場景資訊.是否完成 為 否 )
        {
            print(ao.progress);
            cross.color = new Color(1, 1, 1, ao.progress);               //轉場畫面.顏色 = 新 顏色(1,1,1,透明度)
            yield return new WaitForSeconds(0.01f);
            if (ao.progress >= 0.9f)
            {
                print("偵測是否進來");
                ao.allowSceneActivation = true;      //當 載入進度 >= 0.9 允許切換
            }
        }
    }
}
