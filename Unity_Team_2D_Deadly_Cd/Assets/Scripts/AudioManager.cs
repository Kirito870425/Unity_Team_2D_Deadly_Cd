using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BgAudioSource = null;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Global").Length > 1)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            BgAudioSource.playOnAwake = true;
        }
    }
}
