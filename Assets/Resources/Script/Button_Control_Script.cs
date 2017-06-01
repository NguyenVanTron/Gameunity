using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button_Control_Script : MonoBehaviour
{
    public AudioClip m_soundLogo;
    private AudioSource m_audio;
    public int flag = 0;
    public GameObject Pause_Panel;
    public bool isPause = false;
    // Use this for initialization
    void Start()
    {
        if (Pause_Panel != null)
        {
            Pause_Panel.SetActive(false);
        }
        m_audio = GetComponent<AudioSource>();
        m_audio.clip = m_soundLogo;
        //Pause_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void _ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void _Quit()
    {
        Application.Quit();
    }
    public void _Pause()
    {
          m_audio.Pause();
          Pause_Panel.SetActive(true);
          Time.timeScale = 0;
       
       
    }

    public void _Resume()
    {
        m_audio.Play();
        Time.timeScale = 1;
        Pause_Panel.SetActive(false);
       

    }
    public void _playmusic()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !m_audio.isPlaying)
        if (flag == 0)
        {
            m_audio.Play();
            flag = 1;
        }
        else
        {
            m_audio.Pause();
            flag = 0;
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
            //m_audio.Pause();
    }
    public void _mutemusic()
    {
            m_audio.Pause();
    }
    public void _music()
    {
        m_audio.Play();
    }
}