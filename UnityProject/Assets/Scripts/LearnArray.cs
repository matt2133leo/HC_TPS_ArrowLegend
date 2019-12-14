using UnityEngine;

public class LearnArray : MonoBehaviour
{
    public int enemy1 = 50;
    public int enemy2 = 150;
    public int enemy3 = 90;

    //陣列：類型[]
    public int[] enemys;
    public float[] speeds;
    public GameObject[] enemyObjs;

    //宣告陣列方式
    public int[] array1;                     //定義數量0陣列
    public int[] array2 = new int[10];       //定義數量10陣列
    public int[] array3 = { 100, 200, 300 }; //定義指定資料陣列

    public GameObject[] players;
    private void Awake()
    {
        //存取陣列
        //陣列名稱[索引值]
        print("取得第二筆資料：" + array3[1]);
        //設定：陣列名稱[索引值] = 值
        array3[2] = 999;
        //陣列數量
        print("陣列數量：" + array2.Length);
        //遊戲物件.透過標籤尋找物件(標籤名稱) - 傳回遊戲物件陣列
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
