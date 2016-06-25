using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // dependencies
    public Transform playerPrefab;

    // settings
    public int minSpawnX = -10;
    public int maxSpawnX = -10;
    public int minSpawnY = 2;
    public int maxSpawnY = 2;

    // game state
    private Dictionary<String, Transform> playerMap;
    private Boolean running = false;

    void Start()
    {
        playerMap = new Dictionary<string, Transform>();
    }

    public void spawnPlayer(string id, string name)
    {
        Vector2 position = createRandomPosition(minSpawnX, maxSpawnX, minSpawnY, maxSpawnY);
        // int random = Random.Range(0, 1);
        Transform player = (Transform)Instantiate(playerPrefab, position, Quaternion.identity);
        player.GetComponent<PlayerCharacter>().setName(name);

        playerMap.Add(id, player);
    }

    public void deSpawnPlayer(string name)
    {
        //   playerMap.Remove(name);
        Destroy(playerMap[name].gameObject);
    }

    private Vector2 createRandomPosition(int minX, int maxX, int minY, int maxY)
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    public void movePlayer(string name, Vector2 direction)
    {
        if (running)
        { // TODO improve movement logic
            Transform player = playerMap[name];
            player.GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime * 1000, ForceMode2D.Force);
            //   player.transform.position = direction;
        }
    }

    public void setRunning(Boolean running)
    {
        this.running = running;

        if (running)
        {
            GameObject.FindObjectOfType<SocketIOUnityClient>().socket.Emit("game-running", "");
        }
        else
        {
            GameObject.FindObjectOfType<SocketIOUnityClient>().socket.Emit("game-ended", "");
        }

    }
}