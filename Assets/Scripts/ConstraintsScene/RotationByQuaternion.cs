using UnityEngine;
using UnityEngine.UI;

public class RotationByQuaternion : MonoBehaviour {
    #region
    //   float x = 0;

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {
    //       //x += Time.deltaTime * 10;
    //       //transform.rotation = Quaternion.Euler(x, 0f, 0f);

    //       Vector3 angels = transform.rotation.eulerAngles;
    //       Debug.Log(angels);
    //       angels.x += Time.deltaTime * 10;

    //       transform.rotation = Quaternion.Euler(angels.x ,0,0);
    //}
    #endregion
    // 四元数(Quaternion)的三个分量x,y,z
    float m_MyX, m_MyY, m_MyZ;

    public Slider m_SliderX, m_SliderY, m_SliderZ;

    public Text m_TextX, m_TextY, m_TextZ;


    private void Start()
    {
        // 初始化四元数分量
        m_MyX = 0;
        m_MyY = 0;
        m_MyZ = 0;

        m_SliderX.maxValue = 1;
        m_SliderY.maxValue = 1;
        m_SliderZ.maxValue = 1;

        m_SliderX.minValue = -1;
        m_SliderY.minValue = -1;
        m_SliderZ.minValue = -1;
    }

    private static Quaternion Change(float x, float y, float z)
    {
        return new Quaternion(x, y, z, 1);
    }

    private void Update()
    {
        m_MyX = m_SliderX.value;
        m_MyY = m_SliderY.value;
        m_MyZ = m_SliderZ.value;

        m_TextX.text = "X : " + m_MyX;
        m_TextY.text = "Y : " + m_MyY;
        m_TextZ.text = "Z : " + m_MyZ;

        transform.rotation = Change(m_MyX, m_MyY, m_MyZ);
    }

}
