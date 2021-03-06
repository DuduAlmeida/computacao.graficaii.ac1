using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageUtils : MonoBehaviour
{
  public static AudioSource HealSound;

  // Start is called before the first frame update
  void Start()
  {
    HealSound = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StartGame()
  {
    SceneManager.LoadScene("Game");
  }

  public void ReloadGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void QuitGame()
  {
    // save any game data here
#if UNITY_EDITOR
    // Application.Quit() does not work in the editor so
    // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
    UnityEditor.EditorApplication.isPlaying = false;
#endif

    Application.Quit();
  }

  public static void PlayBonusSound()
  {
    HealSound.Play();
  }
}
