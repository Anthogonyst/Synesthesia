using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class a_LoopBGM : MonoBehaviour
{
	public AudioClip[] songs;
	public AudioClip[] sfx;
	public bool isPlaying = true;
	public bool bootlegMenu = false;

	private static a_LoopBGM _instance;
	private AudioClip playing;
	private AudioSource boombox;
	private int currentSong = -1;
	
    public static a_LoopBGM Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<a_LoopBGM>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        //if this doesn't exist yet...
        if (_instance == null)
            //set instance to this
            _instance = this;
        //If instance already exists and it's not this:
        else if (_instance != null && _instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
	
	public void Start()
	{
		boombox = GetComponent<AudioSource>();
		if (songs.Length > 0)
			PlayMusic();
	}

	public void Update() {
		if (bootlegMenu) {
			if (Input.GetKeyDown(KeyCode.Q))
				Application.Quit();
			if (Input.GetKeyDown(KeyCode.R))
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	
	private void PlayMusic() {
		isPlaying = true;
		
		currentSong++;
		if (currentSong == songs.Length)
			currentSong = 0;
		if (currentSong < 0)
			currentSong = songs.Length - 1;

		boombox.clip = songs[currentSong];
		boombox.Play();
		Invoke("PlayMusic", GetComponent<AudioSource>().clip.length);
	}
	
	public void StopMusic() {
		isPlaying = false;
		CancelInvoke();
		boombox.Stop();
		
	}
	
	public void ResumeMusic() {
		if (isPlaying) return;
		PlayMusic();
	}
	
	public void ToggleMusic() {
		if (isPlaying)
			StopMusic();
		else PlayMusic();
	}
	
	public void NextSong() {
		ChangeSong(currentSong + 1);
	}
	
	public void PreviousSong() {
		ChangeSong(currentSong - 1);
	}
	
	public void ChangeSong(int n) {
		if (n > songs.Length) {
			n = 0;
		} else if (n < 0) {
			n = songs.Length - 1;
		}
			CancelInvoke();
			boombox.Stop();
			currentSong = n - 1;
			PlayMusic();
	}
	
	public void PlaySfx(int n) {
		if (n >= 0 && n < sfx.Length) {
			boombox.PlayOneShot(sfx[n], 1f);
		}
	}
	
	public void ChangeVolume(float v) {
		boombox.volume = v;
	}
}