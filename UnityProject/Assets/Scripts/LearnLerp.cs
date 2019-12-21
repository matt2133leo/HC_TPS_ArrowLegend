using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    private Vector3 a = new Vector3(0, 0, 0);
    private Vector3 b = new Vector3(11, 11, 11);

    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color newColor;

    public float hp = 50;
    private void Start()
    {
        //認識插值
        print(Mathf.Lerp(0,10,0.5f));               //顏色

        print(Vector3.Lerp(a,b,0.5f));              //顏色

        newColor = Color.Lerp(red, blue, 0.5f);     //顏色


        print(Mathf.Clamp(hp, 0, 100));
    }


}