using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnchoredPositionTest : MonoBehaviour
{
    RectTransform rectTransform;
    // Use this for initialization
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();

        Vector2 anchorMax = rectTransform.anchorMax;
        Vector2 anchorMin = rectTransform.anchorMin;
        Debug.Log("anchors: " + "Max" + anchorMax + "Min" + anchorMin);

        Vector2 anchorPosition = rectTransform.anchoredPosition;
        Debug.Log("Pivot 相对于 Anchors 的位置： " + anchorPosition);

        Vector2 sizeDelta = rectTransform.sizeDelta;
        Debug.Log("UI 元素的大小（no stretching）: " + sizeDelta);

        Vector2 offsetMax = rectTransform.offsetMax;
        Vector2 offsetMin = rectTransform.offsetMin;

        Debug.Log("offsetMax 属性指定rect的右上角相对于右上锚点（与实际的Inspector显示为相反数）：" + offsetMax + " offsetMin 属性指定rect的左下角相对于左下锚点：" + offsetMin);
        Debug.Log("Left(offsetMin.x): " + offsetMin.x + " Bottom(offsetMin.y): " + offsetMin.y);
        Debug.Log("Right(offsetMax.x): " + offsetMax.x + " Top(offsetMax.y): " + offsetMax.y);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Press A !!!");
            rectTransform.offsetMax = new Vector2(-507, -91);
            rectTransform.offsetMin = new Vector2(507, 91);
        }
    }
}
