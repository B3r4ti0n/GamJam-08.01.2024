using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_number_block;
    public ChunkScript ChunkInstantiate;

    [SerializeField]
    private GameObject m_GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        Settings.startTime = Time.time;
        CalculateSpawnInterval();
        Settings.initialSpeed = Settings.speed_block;
        Settings.blocksSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Settings._isAlive && IsSpawnTime())
        {
            SpawnChunk();
            if(Settings.speed_block <= 15f){
                UpdateSpeedAndInterval();
            }
        }
    }

    bool IsSpawnTime()
    {
        float elapsedTime = Time.time - Settings.startTime;
        return elapsedTime >= Settings.spawnInterval;
    }

    void SpawnChunk()
    {
        Instantiate(ChunkInstantiate, new Vector3(0, 0, -45), transform.rotation);
        Settings.startTime = Time.time;
        Settings.blocksSpawned++;
    }

    void CalculateSpawnInterval()
    {
        Settings.spawnInterval = Settings.width_block / (Settings.speed_game * Settings.speed_block);
    }

    void UpdateSpeedAndInterval()
    {
        if (Settings.blocksSpawned % Settings.number_block_max == 0)
        {
            Settings.speed_block += 1f;
            CalculateSpawnInterval();
        }
    }
    public void ShowGameOverScreen()
    {
        //TODO : Show Game Over screen
        m_GameOverScreen.SetActive(true);
    }

}
