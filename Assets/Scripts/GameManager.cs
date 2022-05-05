using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnHazards());
    }

    // Update is called once per frame
    void Update() {
        
    }   

    private IEnumerator SpawnHazards() {
        var hazardToSpawn = Random.Range(1, 5);

        for (int i = 0; i < hazardToSpawn; i++)
        {
            var x = Random.Range(-12f,12f);
            var drag = Random.Range(0f, 3f);
            var hazard = Instantiate(hazardPrefab, new Vector3(x,11,12), Quaternion.identity);
            
            hazard.GetComponent<Rigidbody>().drag = drag;
        }


        yield return new WaitForSeconds(1f);

        yield return SpawnHazards();
    }
}