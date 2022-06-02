using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject hazardPrefab;
  public static AudioSource HitSound;
  public TMPro.TextMeshPro scoreText;
  public GameObject restartMenuCanvas;

  private int score = 0;
  private float timer;
  private static bool isGameOver = false;
  void Start()
  {
    HitSound = GetComponent<AudioSource>();
    StartCoroutine(SpawnHazards());
  }

  // Update is called once per frame
  void Update()
  {
    restartMenuCanvas.gameObject.SetActive(isGameOver);
    
    if (isGameOver) return;

    timer += Time.deltaTime;

    if (timer >= 1f)
    {
      score += 1;
      scoreText.text = score.ToString();

      timer = 0;
    }
  }

  private IEnumerator SpawnHazards()
  {
    var hazardToSpawn = Random.Range(1, 3);

    for (int i = 0; i < hazardToSpawn; i++)
    {
      var x = Random.Range(-12f, 12f);
      var drag = Random.Range(0f, 3f);

      if (!isGameOver && i == 2) x = move.GetPlayerXPosition() + 3.5f;

      var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 12), Quaternion.identity);

      hazard.GetComponent<Rigidbody>().drag = drag;
    }


    yield return new WaitForSeconds(1f);

    yield return SpawnHazards();
  }

  public static void GameOver()
  {
    HitSound.Play();
    isGameOver = true;
  }

  public static void RestartGame()
  {
    isGameOver = false;
  }
}
