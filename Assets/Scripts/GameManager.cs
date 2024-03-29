﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SVGImporter;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // dependencies
    public Transform playerPrefab;

    // settings
    public int minSpawnX = -5;
    public int maxSpawnX = -5;
    public int minSpawnY = 5;
    public int maxSpawnY = 5;

    // game state
    private Dictionary<String, Transform> playerMap;
    private Boolean running = false;

    void Start()
    {
        running = true;
        playerMap = new Dictionary<string, Transform>();
    }

    public void spawnPlayer(string id, string name)
    {
        Vector2 position = createRandomPosition(minSpawnX, maxSpawnX, minSpawnY, maxSpawnY);
        // int random = Random.Range(0, 1);
        Transform player = (Transform)Instantiate(playerPrefab, position, Quaternion.identity);
        player.GetComponent<PlayerCharacter>().setName(name);

        string svgName = "skate-guy";
        if (Random.Range(0, 2) == 1)
        {
            svgName = "skate-girl";
        }

        SVGAsset playerSvg = GameObject.FindObjectOfType<SVGContainer>().getSvg(svgName);
        player.GetComponent<SVGRenderer>().vectorGraphics = playerSvg;
        player.GetChild(0).GetComponent<SVGRenderer>().color = GameObject.FindObjectOfType<ColorHelper>().RandomColor();
        player.parent = GameObject.FindGameObjectWithTag("Board").transform;
        playerMap.Add(id, player);
    }

    public void deSpawnPlayer(string name)
    {
        if (playerMap.ContainsKey(name))
        {
            Destroy(playerMap[name].gameObject);
            playerMap.Remove(name);
        }

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
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * 500 * Time.deltaTime, 0);
            player.localScale = new Vector2((direction.x < 0 ? -1 : 1) * 0.5F, player.localScale.y);

     //       if(direction.y > 0)
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, direction.y) * Time.deltaTime * 10000, ForceMode2D.Force);
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