using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject passimage;

    public void pass()
    {
        passimage.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "過關區域")
            pass();
    }
}
