using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManagement : MonoBehaviour
{
    public RectTransform m_RectTransform;

    public IEnumerator ShowProductionTeam()
    {
        while (m_RectTransform.anchoredPosition.y > -1000)
        {
            m_RectTransform.anchoredPosition -= new Vector2(0, 200 * Time.deltaTime);
            yield return null;
        }
    }
    public void Show()
    {
        StartCoroutine(ShowProductionTeam());
    }
}
