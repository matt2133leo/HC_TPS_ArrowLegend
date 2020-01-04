using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HpBarControl : MonoBehaviour
{
    private Image imgHp;
    private Text textHp;
    private Text textdamagehp;

    private void Start()
    {
        imgHp = transform.GetChild(1).GetComponent<Image>();
        textHp = transform.GetChild(2).GetComponent<Text>();
        textdamagehp = transform.GetChild(3).GetComponent<Text>();
    }
    private void Update()
    {
        AngleControl();
    }

    /// <summary>
    /// 角度控制:讓血條保持世界座標角度為原本角度 
    /// </summary>
    private void AngleControl()
    {
        transform.eulerAngles = new Vector3(125,360,0);
    }
    /// <summary>
    /// 更新血條圖片長度與文字內容，需要提供最大與目前血量
    /// </summary>
    /// <param name="hpMax">最大血量</param>
    /// <param name="hpCurrent">目前血量，受傷後的血量</param>
    public void UpdateHpBar(float hpMax, float hpCurrent)
    {
        imgHp.fillAmount = hpCurrent / hpMax;    //圖片.填滿數值 = 目前 / 最大
        textHp.text = hpCurrent.ToString();      //文字.文字內容 = 目前.轉字串()
    }
    #region 老師製作(傷害值往上移動)
    
    /// <summary>
    /// 顯示傷害值效果：傷害值往上移動
    /// 老師製作(傷害值往上移動)
    /// </summary>
    /// <param name="damage">玩家受多少傷害</param>
    /// <returns></returns>
    public IEnumerator ShowDamage(float damage)
    {
        Vector3 posOriginal = textdamagehp.transform.position;
        textdamagehp.text = "-" + damage;         // 更新傷害值 = 接收傷害
        //迴圈
        for (int i = 0; i < 20; i++)
        {
            textdamagehp.transform.position += new Vector3(0, 0.02f, 0);

            yield return new WaitForSeconds(0.01f);
        }
        textdamagehp.transform.position = posOriginal;
        textdamagehp.text = "";
    }
    
    #endregion

    #region 自己製作的
        
    public IEnumerator playerdamage()
    {
        Vector3 posOriginal = textdamagehp.transform.position;

        textdamagehp.text ="-" +  GameObject.Find("殭屍").GetComponent<Enemy>().data.atk.ToString();

        for (int i = 0; i < 10; i++)
        {

            textdamagehp.transform.position += new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        // 協程方法：顯示傷害值 - 接收傷害
        // 更新傷害值 = 接收傷害
        // 迴圈
        // 傷害值往上移動
        // 等待
        textdamagehp.transform.position = posOriginal;
        textdamagehp.text = "";
    }
    #endregion
}
