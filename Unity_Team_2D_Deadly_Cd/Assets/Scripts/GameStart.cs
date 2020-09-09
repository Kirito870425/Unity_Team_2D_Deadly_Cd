using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject startbg;
    public GameObject characterbg;
    public GameObject checkpointbg;

    public void Gamestart()
    {
        SceneManager.LoadScene("遊戲場景");
    }
    public void Character()
    {
        startbg.SetActive(false);
        characterbg.SetActive(true);
        checkpointbg.SetActive(false);
    }
    public void Checkpoint()
    {
        startbg.SetActive(false);
        characterbg.SetActive(false);
        checkpointbg.SetActive(true);
    }
}
