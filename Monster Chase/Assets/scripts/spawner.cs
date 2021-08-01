using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject[] monsterReference;
    [SerializeField] Transform leftPos, rightPos;
    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0) //left side
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemies>().speed = Random.Range(4, 20);
            }
            else // right side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemies>().speed = -Random.Range(4, 15);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
       
    }
}
