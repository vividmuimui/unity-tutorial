using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
	[Serializable]
	public class Count
	{
		public int minumum;
		public int maximum;
		public Count (int min, int max)
		{
			minumum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	public Count wallCount = new Count(5, 9);
	public Count foodCount = new Count(1, 5);
	public GameObject exit;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outWallTiles;

	Transform boardHolder;
	List<Vector3> gridPositions = new List<Vector3>();

	void InitializeList()
	{
		gridPositions.Clear();
		for(int x = 1; x < columns - 1; x++)
		{
			for(int y = 1; y <= rows - 1; y++)
			{
				gridPositions.Add(new Vector3(x, y, 0f));
			}
		}
	}

	void BoardSetup()
	{
		boardHolder = new GameObject("Board").transform;
		for(int x = -1; x < columns + 1; x++)
		{
			for(int y = -1; y < columns + 1; y++)
			{
				GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
				if( x == -1 || x == columns || y == -1 || y == rows)
				{
					toInstantiate = outWallTiles[Random.Range(0, outWallTiles.Length)];
				}
				GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
			}
		}
	}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range(0, gridPositions.Count);
		Vector3 randomPosition = gridPositions[randomIndex];
		gridPositions.RemoveAt(randomIndex);
		return randomPosition;
	}

	public void SetupScene(int level)
	{
		BoardSetup();
		InitializeList();
		LayerObjectAtRandom(wallTiles, wallCount.minumum, wallCount.maximum);
		LayerObjectAtRandom(foodTiles, foodCount.minumum, foodCount.maximum);
		int enemyCount = (int)Mathf.Log(level);
		LayerObjectAtRandom(enemyTiles, enemyCount, enemyCount);
		Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
	}

	void LayerObjectAtRandom(GameObject[] tileArray, int minumum, int maximum)
	{
		int objectCount = Random.Range(minumum, maximum + 1);
		for (int i = 0; i < objectCount; i ++)
		{
			Vector3 randomPosition = RandomPosition();
			GameObject tileChoise = tileArray[Random.Range(0, tileArray.Length)];
			Instantiate(tileChoise, randomPosition, Quaternion.identity);
		}
	}

	void Start () {
		
	}
	
	void Update () {
	
	}
}
