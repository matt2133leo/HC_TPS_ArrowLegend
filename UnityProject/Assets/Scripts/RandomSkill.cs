using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//[添加元件(類型(任何元件類型))] - 套用此腳本時執行
[RequireComponent(typeof(AudioSource))]
public class RandomSkill : MonoBehaviour
{
    #region 欄位
    [Header ("技能隨機圖片")]
    public Sprite[] spritesRandom;

    [Header("技能圖片")]
    public Sprite[] sprites;

    [Header("間隔時間"), Range(0f, 1f)]
    public float speed = 0.1f;

    [Header("次數"), Range(1, 10)]
    public int count = 3;

    [Header("音效區域")]

    public AudioClip RandomSkillAC;
    public AudioClip SkillAC;

    [Header("技能隨機值")]
    public int skillrandom_int;

    [Header("技能名稱")]
    public string[] skillName = { "連射", "添加弓箭", "前後", "左右", "添加血量", "添加攻擊", "添加攻速", "增加暴傷" };

    private AudioSource RandomSkillAud;
    private Image imgSkill;
    private Text textSkill;

    #endregion

    private Button btn;
    private GameObject objSkill;

    private void Start()
    {
        
        imgSkill = GetComponent<Image>();
        RandomSkillAud = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        textSkill = transform.GetChild(0).GetComponent<Text>();  // 變形.取得子物件(索引值)
        objSkill = GameObject.Find("隨機技能");

        StartCoroutine(StartRandom());                           //啟動協程(開始隨機())

        btn.onClick.AddListener(ChooseSkill);                    //按鈕.點擊事件.增加聆聽者(方法)
    }

    /// <summary>
    /// 選取技能
    /// </summary>
    private void ChooseSkill()
    {
        print("選取技能!" + skillName[skillrandom_int]);
        objSkill.SetActive(false);

    }

    /// <summary>
    /// 開始隨機效果
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartRandom()
    {
        btn.interactable = false;
        for (int j = 0; j < count; j++)
        {
        for (int i = 0; i < spritesRandom.Length ; i++)
        {
            imgSkill.sprite = spritesRandom[i];                    //技能圖片.圖片 = 圖片隨機[索引值]
            RandomSkillAud.PlayOneShot(RandomSkillAC, 0.5f);       //音源.播放一次音效(音效片段，音量）
            yield return new WaitForSeconds(speed);                //等待

        }
        }

        // 隨機值 = 隨機.範圍(最大，最小）
        // 技能圖片.圖片 = 技能圖片[隨機值]
        // 技能.播放一次音效(音效片段,音量)

        skillrandom_int = Random.Range(0, sprites.Length);
        imgSkill.sprite = sprites[skillrandom_int];
        textSkill.text = skillName[skillrandom_int];
        RandomSkillAud.PlayOneShot(SkillAC, 0.5f);
        btn.interactable = true;



    }
}
