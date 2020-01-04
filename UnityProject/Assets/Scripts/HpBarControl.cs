using UnityEngine;

public class HpBarControl : MonoBehaviour
{
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
}
