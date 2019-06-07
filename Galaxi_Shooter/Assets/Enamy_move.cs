using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy_move : MonoBehaviour
{
    public enum SpawnState{SPAWNING , WAITING,COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int _NextWave = 0;
    public float TimeBetweenWaves = 5f;
    public float Wavecountdown;

    private float searchcountdown = 1f;


    private SpawnState state = SpawnState.COUNTING;



     void Start()
    {
        Wavecountdown = TimeBetweenWaves;

    }


     void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //checar si el enemigo a un esta vivo
            if (!EnemyIsAlive())
            {
                //new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        
        if(Wavecountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //espesar a crear una orda de alien
                StartCoroutine(SpawnWave(waves[_NextWave]));

            }
        }
        else
        {
            Wavecountdown -= Time.deltaTime;
        }
    }
    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        Wavecountdown = TimeBetweenWaves;

        if(_NextWave + 1 > waves.Length - 1)
        {
            _NextWave = 0;
            Debug.Log("All wave or completed");
        }
        else
        {
            _NextWave++;
        }
        
    }
    bool EnemyIsAlive()
    {
        searchcountdown -= Time.deltaTime;
        if(searchcountdown <= 0f)
        {
            searchcountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
         return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawn Wave :" + _wave.name);
        state = SpawnState.SPAWNING;
        for(int i =0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }


    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawing Enemy :" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }


}
