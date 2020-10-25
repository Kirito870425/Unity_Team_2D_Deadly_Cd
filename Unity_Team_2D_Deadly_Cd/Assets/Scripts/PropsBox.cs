using UnityEngine;

public class PropsBox : MonoBehaviour
{
    public GameObject test;
    private Color _test = new Color();
    private float _tmp = 0;

    private void Awake()
    {
        test.GetComponent<SpriteRenderer>().color = _test;
    }
    private void Update()
    {
        _tmp += Time.deltaTime;
        if (_tmp >= 0.5f)
        {
            print(123);
            _tmp = 0;
            _test.a -= 0.1f;
        }
    }
}
