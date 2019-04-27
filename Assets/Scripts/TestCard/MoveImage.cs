using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour{

    private Image itemOriginal;
    public RectTransform contentRect;
    //private ScrollRect scrollRect;
    
    private  Image[] items;

    public readonly int sumCount = 20; // 总的卡片数
    //private int pressCount = 0;
    private int leftCount = 0; // 先左加后右减
    //private int rightToLeftCount = 4; // 先右减后左加
    private int rightCount = 5; // content的最多个数显示 - 2，从零开始 初始值是content的count，从零开始计数，4就是5

    // 用于检测标记
    private RectTransform subLeftImageMark;
    private RectTransform leftImageMark;
    private RectTransform subRightImageMark;
    private RectTransform rightImageMark;

    // 
    private RectTransform leftSubImageRoot;
    private RectTransform rightSubImageRoot;

    // 计算SrollView的移动方向
    private float contentFirstPosX;
    private float contentSecondPosX;
    private float offset;

    private void Awake()
    {
       
        itemOriginal = Resources.Load<Image>("Image");

        //scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();

        contentRect = GameObject.Find("Content").GetComponent<RectTransform>();

        subLeftImageMark = GameObject.Find("SubLeftImageMark").GetComponent<RectTransform>();
        leftImageMark = GameObject.Find("LeftImageMark").GetComponent<RectTransform>();
        subRightImageMark = GameObject.Find("SubRightImageMark").GetComponent<RectTransform>();
        rightImageMark = GameObject.Find("RightImageMark").GetComponent<RectTransform>();

        leftSubImageRoot = GameObject.Find("LeftSubImageRoot").GetComponent<RectTransform>();
        rightSubImageRoot = GameObject.Find("RightSubImageRoot").GetComponent<RectTransform>();
        
    }
    /* LEFT <<-----          ----->> RIGHT */
    void Start () {
        items = new Image[sumCount]; // 用于存放item的数组

        // 初始化生成item
        if (itemOriginal != null && contentRect != null) { 
            for (int i = 0; i < sumCount; ++i) {
                items[i] = Instantiate<Image>(itemOriginal);
                items[i].name = "item" + i;
                items[i].transform.SetParent(contentRect, false);
                // 初始时，折叠卡牌 0,1,2,3,4,
                if (i >= 5) 
                {
                    RectTransform subItem = (RectTransform)items[i].rectTransform.GetChild(0);
                    subItem.name = "sub" + items[i].name;
                    subItem.SetParent(rightSubImageRoot);
                    subItem.localPosition = new Vector3(275f, 45f);

                    subItem.SetAsFirstSibling();
                }
            }
            SetInitPos();
        }
        
        contentFirstPosX = contentRect.localPosition.x; // 0
    }
	
	void Update ()
    {

        SetImageAlpha(rightSubImageRoot);
        SetImageAlpha(leftSubImageRoot);

        contentSecondPosX = contentRect.localPosition.x;
        offset = contentFirstPosX - contentSecondPosX;


        #region
        // left 折叠卡牌 <<---- 展开卡牌
        if (offset > 0)
        {
            Debug.Log("Left");

            #region 折叠卡牌到左边
            // 折叠右边的卡牌重叠到左边
            if (leftCount < sumCount)
            {
                RectTransform itemo = items[leftCount].rectTransform;
                if (IsRectTransformOverlap(subLeftImageMark, itemo) && sumCount > 3)
                {
                    RectTransform subItem = (RectTransform)itemo.GetChild(0);
                    subItem.name = "sub" + itemo.name;
                    subItem.SetParent(leftSubImageRoot);
                    subItem.SetAsLastSibling();
                    subItem.localPosition = new Vector2(-275f, 45f);
                    SetLeftLPos();
                    leftCount++;
                }
            }
            #endregion

            #region 展开右边的卡牌
            // 展开
            if (rightCount < sumCount ) {
                RectTransform itemL = items[rightCount].rectTransform;
                if (IsRectTransformOverlap(rightImageMark, itemL) && itemL.childCount == 0)
                {
                    string subItemname = "sub" + itemL.name;
                    RectTransform subItem = (RectTransform)GameObject.Find(subItemname).transform;
                    subItem.SetParent(itemL);
                    subItem.localPosition = new Vector3(0f, 0f);
                    SetLeftRPos();
                    if (itemL.childCount == 1)
                    {
                        rightCount++;
                    }
                }
            }
            #endregion
        }
        // right 展开卡牌 ----->> 折叠卡牌
        else if (offset < 0) {
            Debug.Log("Right");

            #region 展开左边的卡牌
            // 展开左边重叠的卡牌的到右边
            if (leftCount > 0) {
                RectTransform itemoo = items[leftCount - 1].rectTransform;
                if (IsRectTransformOverlap(leftImageMark, itemoo) && itemoo.childCount == 0)
                {
                    string subItemname = "sub" + itemoo.name;
                    RectTransform subItem = (RectTransform)GameObject.Find(subItemname).transform;
                    subItem.SetParent(itemoo);
                    subItem.localPosition = new Vector2(0f, 0f);
                    SetRightLPos();
                    if (itemoo.childCount == 1)
                    {
                        leftCount--;
                    }
                }
            }
            #endregion

            #region 折叠卡牌到右边
            // 折叠
            if (rightCount > 0) {
                Debug.Log("==============>>>>>>>>>>>========>>>>>>>." + rightCount);
                RectTransform itemLL = items[rightCount-1].rectTransform;
                if (IsRectTransformOverlap(subRightImageMark, itemLL))
                {
                    RectTransform subItem = (RectTransform)itemLL.GetChild(0);
                    subItem.name = "sub" + itemLL.name;
                    subItem.SetParent(rightSubImageRoot);
                    subItem.localPosition = new Vector3(275f, 45f);
                    subItem.SetAsLastSibling();
                    rightCount--;
                    SetRightRPos();

                }
            }
            #endregion
        }
        #endregion

        contentFirstPosX = contentSecondPosX;
    }

    public static bool IsRectTransformOverlap(RectTransform rect1, RectTransform rect2)
    {
        float rect1MinX = rect1.position.x - rect1.rect.width / 2;
        float rect1MaxX = rect1.position.x + rect1.rect.width / 2;
        float rect1MinY = rect1.position.y - rect1.rect.height / 2;
        float rect1MaxY = rect1.position.y + rect1.rect.height / 2;

        float rect2MinX = rect2.position.x - rect2.rect.width / 2;
        float rect2MaxX = rect2.position.x + rect2.rect.width / 2;
        float rect2MinY = rect2.position.y - rect2.rect.height / 2;
        float rect2MaxY = rect2.position.y + rect2.rect.height / 2;

        bool xNotOverlap = rect1MaxX <= rect2MinX || rect2MaxX <= rect1MinX;
        bool yNotOverlap = rect1MaxY <= rect2MinY || rect2MaxY <= rect1MinY;

        bool notOverlap = xNotOverlap || yNotOverlap;

        return !notOverlap;
    }

    //public static bool RectIntersect(Rect a, Rect b) {
    //    float xMin = Mathf.Max(a.x, b.x);
    //    float xMax = Mathf.Min(a.x + a.width, b.x + b.width);
    //    float yMin = Mathf.Max(a.y, b.y);
    //    float yMax = Mathf.Min(a.y + a.height, b.y + b.height);
    //    if (xMax >= xMin && yMax >= yMin) {
    //        return true;
    //    }
    //    return false;
    //}

    // ----->> 左滑左边的卡牌堆叠
    public void SetLeftLPos() 
    {
        Debug.Log("堆叠在左边的卡牌的数量 ：" + leftSubImageRoot.childCount);

        int lchildCount = leftSubImageRoot.childCount;
        if (lchildCount == 2)
        {
            Vector3 lchildOnePos = leftSubImageRoot.GetChild(0).localPosition;
            leftSubImageRoot.GetChild(0).localPosition = new Vector3(lchildOnePos.x - 25f / 2f, lchildOnePos.y - 20f / 2f);
        }
        else if (lchildCount >= 3)
        {
            Vector3 lchildThreePos = leftSubImageRoot.GetChild(lchildCount - 3).localPosition;
            leftSubImageRoot.GetChild(lchildCount - 3).localPosition = new Vector3(lchildThreePos.x - 25f / 2f, lchildThreePos.y - 20f / 2f);

            Vector3 lchildTwoPos = leftSubImageRoot.GetChild(lchildCount - 2).localPosition;
            leftSubImageRoot.GetChild(lchildCount - 2).localPosition = new Vector3(lchildTwoPos.x - 25f / 2f, lchildTwoPos.y - 20f / 2f);
        }
    }

    // ----->> 左滑右边的卡牌展开
    public void SetLeftRPos()
    {
        Debug.Log("堆叠在右边的卡牌的数量 ：" + rightSubImageRoot.childCount);

        int rchildCount = rightSubImageRoot.childCount;
        if (rchildCount == 1)
        {
            Vector3 rchildOnePos = rightSubImageRoot.GetChild(0).localPosition;
            rightSubImageRoot.GetChild(0).localPosition = new Vector3(rchildOnePos.x - 25f / 2f, rchildOnePos.y + 20f / 2f);
        }
        else if (rchildCount > 1)
        {
            Vector3 rchildThreePos = rightSubImageRoot.GetChild(rchildCount - 2).localPosition;
            rightSubImageRoot.GetChild(rchildCount - 2).localPosition = new Vector3(rchildThreePos.x - 25f / 2f, rchildThreePos.y + 20f / 2f);

            Vector3 rchildTwoPos = rightSubImageRoot.GetChild(rchildCount - 1).localPosition;
            rightSubImageRoot.GetChild(rchildCount - 1).localPosition = new Vector3(rchildTwoPos.x - 25f / 2f, rchildTwoPos.y + 20f / 2f);
        }
    }

    // ----->>> 右滑左边的卡牌展开
    public void SetRightLPos() 
    {
        Debug.Log("堆叠在左边的卡牌的数量 ：" + leftSubImageRoot.childCount);
        int lchildCount = leftSubImageRoot.childCount;

        if (lchildCount == 1)
        {
            Vector3 lchildTwoPos = leftSubImageRoot.GetChild(0).localPosition;
            leftSubImageRoot.GetChild(0).localPosition = new Vector3(lchildTwoPos.x + 25f / 2, lchildTwoPos.y + 20f / 2);

        }
        else if (lchildCount > 1)
        {
            Vector3 lchildThreePos = leftSubImageRoot.GetChild(lchildCount - 2).localPosition;
            leftSubImageRoot.GetChild(lchildCount - 2).localPosition = new Vector3(lchildThreePos.x + 25f / 2, lchildThreePos.y + 20f / 2);

            Vector3 lchildTwoPos = leftSubImageRoot.GetChild(lchildCount - 1).localPosition;
            leftSubImageRoot.GetChild(lchildCount - 1).localPosition = new Vector3(lchildTwoPos.x + 25f / 2, lchildTwoPos.y + 20f / 2);
        }
    }

    // ----->>> 右滑右边的卡牌堆叠
    public void SetRightRPos()
    {
        Debug.Log("堆叠在右边的卡牌的数量 ：" + rightSubImageRoot.childCount);
        int rchildCount = rightSubImageRoot.childCount;

        if (rchildCount == 2)
        {
            Vector3 rchildTwoPos = rightSubImageRoot.GetChild(0).localPosition;
            rightSubImageRoot.GetChild(0).localPosition = new Vector3(rchildTwoPos.x + 25f / 2, rchildTwoPos.y - 20f / 2);
        }
        else if (rchildCount >= 3)
        {
            Vector3 rchildThreePos = rightSubImageRoot.GetChild(rchildCount - 3).localPosition;
            rightSubImageRoot.GetChild(rchildCount - 3).localPosition = new Vector3(rchildThreePos.x + 25f / 2, rchildThreePos.y - 20f / 2);

            Vector3 rchildTwoPos = rightSubImageRoot.GetChild(rchildCount - 2).localPosition;
            rightSubImageRoot.GetChild(rchildCount - 2).localPosition = new Vector3(rchildTwoPos.x + 25f / 2, rchildTwoPos.y - 20f / 2);
        }
    }

    // 初始化
    public void SetInitPos() {
        Debug.Log("堆叠在右边的卡牌的数量 ：" + rightSubImageRoot.childCount);
        int rchildCount = rightSubImageRoot.childCount;

        if (rchildCount == 2)
        {
            Vector3 rchildTwoPos = rightSubImageRoot.GetChild(0).localPosition;
            rightSubImageRoot.GetChild(0).localPosition = new Vector3(rchildTwoPos.x + 25f / 2, rchildTwoPos.y - 20f / 2);
        }
        else if (rchildCount >= 3)
        {
            for (int i = rchildCount - 3; i >= 0; --i) {
                Vector3 rchildPos = rightSubImageRoot.GetChild(i).localPosition;
                rightSubImageRoot.GetChild(i).localPosition = new Vector3(rchildPos.x + 25f, rchildPos.y - 20f);
                Debug.Log(rightSubImageRoot.GetChild(i).localPosition);
            }
            Vector3 rchildTwoPos = rightSubImageRoot.GetChild(rchildCount - 2).localPosition;
            rightSubImageRoot.GetChild(rchildCount - 2).localPosition = new Vector3(rchildTwoPos.x + 25f / 2, rchildTwoPos.y - 20f / 2);
        }
    }

    public void SetImageAlpha(RectTransform SubImageRoot)
    {
        for (int i = 0; i < SubImageRoot.childCount; ++i)
        {
            int childCount = SubImageRoot.childCount;
            Image subImage = SubImageRoot.GetChild(i).GetComponent<Image>();

            if (i == childCount - 1)
            {
                subImage.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (i == childCount - 2)
            {
                subImage.color = new Color(1f, 1f, 1f, 0.7f);
            }
            else if (i == childCount - 3)
            {
                subImage.color = new Color(1f, 1f, 1f, 0.3f);
            }
            else
            {
                subImage.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }
}
