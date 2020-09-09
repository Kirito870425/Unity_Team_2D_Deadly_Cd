using UnityEngine;

public class Props : MonoBehaviour
{
    public Vector3 oldpos;
    public GameObject propbg;
    public Props props;

    #region 滑鼠功能

    private void OnMouseDown()
    {
        propbg.gameObject.SetActive(false);
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10;
        oldpos = Camera.main.ScreenToWorldPoint(mouse);
    }
    private void OnMouseDrag()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10;//攝影機位置大小
        Vector3 newpos = Camera.main.ScreenToWorldPoint(mouse);//轉換成遊戲世界座標(攝影機距離)
        Vector3 offset = newpos - oldpos;
        transform.position += offset;
        oldpos = Camera.main.ScreenToWorldPoint(mouse);//歸零作用
    }
    private void OnMouseUp()
    {
        Destroy(props);
    }

    #endregion

    private void Start()
    {
        propbg.gameObject.SetActive(true);
    }
}
