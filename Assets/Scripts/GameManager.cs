using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int m_number_block;
    public ChunkScript ChunkInstantiate;
    public int m_count = 0;

    [SerializeField]
    private GameObject m_GameOverScreen;

    [SerializeField] 
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 45; i+=5)
        {
            SpawnChunk(-i);
        }

        Settings.startTime = Time.time;
        CalculateSpawnInterval();
        Settings.initialSpeed = Settings.speed_block;
        Settings.blocksSpawned = 0;
        Settings._isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Settings._isAlive && Settings._isActivated){
            StartCoroutine(DelayedAction());
        }
        if(Settings._isAlive && IsSpawnTime())
        {
            SpawnChunk(-45);
            if(Settings.speed_block <= 15f){
                UpdateSpeedAndInterval();
            }
        }else if(Settings._isActivated) {
            m_count++;
            player.transform.Rotate(0f, -0.7f, 0f);

            player.transform.Translate(Vector3.forward * 5 * Time.deltaTime);

            if(m_count >= 100){
                Settings._isActivated = false;
            }
        } else {

        }
    }

    bool IsSpawnTime()
    {
        float elapsedTime = Time.time - Settings.startTime;
        return elapsedTime >= Settings.spawnInterval;
    }

    void SpawnChunk(int z)
    {
        Instantiate(ChunkInstantiate, new Vector3(0, 0, z), transform.rotation);
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

    private void ShowGameOverScreen()
    {
        //TODO : Show Game Over screen
        // m_GameOverScreen.SetActive(true);
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1f);
        ShowGameOverScreen();
    }

}
