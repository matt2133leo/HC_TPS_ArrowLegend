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
     AsyncOperation ao = SceneManager.LoadSceneAsync("關卡2");
        print(ao.progress);
        yield return new WaitForSeconds(0.01f);
        print(ao.progress);
        yield return new WaitForSeconds(0.01f);
        print(ao.progress);
        yield return new WaitForSeconds(0.01f);
    }
}
