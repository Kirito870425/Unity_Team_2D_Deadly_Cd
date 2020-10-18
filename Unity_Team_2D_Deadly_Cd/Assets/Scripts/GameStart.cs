using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject startbg;
    public GameObject characterbg;
    public GameObject checkpointbg;
    public GameObject player1GO;
    public GameObject player2GO;

    public RawImage treeRawImage;
    public RawImage flowerRawImage;
    public Texture treeTexture;
    public Texture flowerTexture;
    public bool player1CheckBool;
    public bool player2CheckBool;

    private void MainGameStart()
    {
        if (player1CheckBool && player2CheckBool)
        {
            SceneManager.LoadScene("遊戲場景");
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Checkpoint()
    {
        startbg.SetActive(false);
        characterbg.SetActive(true);
    }
    private void Change()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            flowerRawImage.texture = flowerTexture;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            flowerRawImage.texture = treeTexture;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            treeRawImage.texture = treeTexture;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            treeRawImage.texture = flowerTexture;
        }
        /*if (Input.GetKeyDown(KeyCode.Space) && player1CheckBool)
        {
            player1CheckBool = false;
            player1GO.SetActive(false);
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player1CheckBool = true;
            player1GO.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            player2CheckBool = true;
            player2GO.SetActive(true);
        }
    }


    private void Update()
    {
        MainGameStart();
        Change();
    }
}
