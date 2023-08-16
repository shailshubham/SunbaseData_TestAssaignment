using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Circle Position Data for Instantiation")]
    [SerializeField] int xPosMin = -10;
    [SerializeField] int xPosMax = 10;
    [SerializeField] int yPosMin = -4;
    [SerializeField] int yPosMax = 4;
    List<Vector2> instatiationPositions = new List<Vector2>();
    List<GameObject> circles = new List<GameObject>();
    public static GameManager instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        if(instance!=this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ListingRandomPositionsToForInstantiate();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRestartButtonClick()
    {
        foreach(GameObject c in circles)
        {
            c.SetActive(false);
        }
        circles.Clear();

        StartGame();
    }

    void StartGame()
    {
        int circleCount = UnityEngine.Random.Range(5, 10);
        List<Vector2> tempPositions = instatiationPositions;
        for(int i = 0;i<circleCount; i++)
        {
            int index = UnityEngine.Random.Range(0, tempPositions.Count);
            GameObject obj = ObjectPooler.instance.SpawnFromPool("circle", new Vector3(tempPositions[index].x, tempPositions[index].y,0), quaternion.identity);
            circles.Add(obj);
            tempPositions.Remove(tempPositions[index]);
        }
    }

    void ListingRandomPositionsToForInstantiate()
    {
        for(int x = xPosMin;x != xPosMax; x=x+2)
        {
            for (int y = yPosMin; y != yPosMax; y = y + 2)
            {
                instatiationPositions.Add(new Vector2((float)x, (float)y));
            }
        }
    }
}
