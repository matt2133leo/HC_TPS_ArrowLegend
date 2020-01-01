
using UnityEngine;

public class Player : MonoBehaviour
{

    #region 欄位
    [Header("移動速度"), Range(1, 2000), Tooltip("調整移動速度")]
    public float speed = 10;

    [SerializeField] private Animator CharacterAni;
    [SerializeField] private Joystick joy;
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody rig;
    #endregion

    private LevelManager levelManager;

    #region 事件
    private void Start()
    {
        //剛體欄位 = 取得元件<泛型>()
        rig = GetComponent<Rigidbody>();
        //target = GameComponent<Transform>();       //寫法1
        target = GameObject.Find("目標").transform;  //寫法2 p.s. transform可以這樣寫,請參照 Unity API 
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();

        levelManager = FindObjectOfType<LevelManager>();

        CharacterAni = GetComponent<Animator>();
    }

    private void Update()
    {
        //測試區域
        if (Input.GetKeyDown(KeyCode.Alpha1)) Attack();
        if (Input.GetKeyDown(KeyCode.Alpha2)) Dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "傳送區域")
        {
            levelManager.StartCoroutine("LoadLevel");
        }
    }


    private void FixedUpdate()
    {
        move();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動玩家方法
    /// </summary>
    private void move()
    {
        float h = joy.Horizontal;
        float v = joy.Vertical;
        rig.AddForce( -h*speed, 0,-v*speed);

        //取得此物件變型元件
        //原本寫法：GetComponent<Transform>(); 取得物件本身Transform
        //簡寫：transform

        Vector3 posPlayer = transform.position;                                     // 取得玩家座標
        Vector3 posTarget = new Vector3(posPlayer.x - h*2, 0, posPlayer.z - v*2);   // 目標座標 = 新 三維向量(玩家.X + 搖桿.x, Y , 玩家.Z+搖桿.Z)

        target.position = posTarget;                                               //目標.座標 = 目標座標

        posTarget.y = posPlayer.y;      //目標.Y = 玩家.Y(避免吃土)

        transform.LookAt(posTarget);    //變形.看著(座標)

        //水平 1 、 -1
        //垂直 1 、 -1
        //動畫控制器.設定布林值(參數名稱,布林值)
        CharacterAni.SetBool("跑步開關", h != 0 || v != 0);

    }

    private void Attack()
    {
        CharacterAni.SetTrigger("攻擊觸發");
        //播放攻擊動畫 SetTrigger("參數名稱")
    }

    private void Hit(float damage)
    {

    }

    private void Dead()
    {
        CharacterAni.SetBool("死亡開關", true);
        //播放死亡動畫 SetBool ("參數名稱", 布林值)
    }


    #endregion

}
