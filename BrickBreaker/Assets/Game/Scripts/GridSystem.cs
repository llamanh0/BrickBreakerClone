using System;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static event EventHandler<OnLevelStartEventArgs> OnLevelStart;
    public class OnLevelStartEventArgs : EventArgs
    {
        public int brickCount;
    }

    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private Vector2 startPos = new Vector2(-40, 20);

    [SerializeField] private LevelDifficultySO levelDifficulty;


    private int row;
    private int col;
    private float _spaceX;
    private float _spaceY;
    private readonly List<Vector2> _gridList = new List<Vector2>();

    private void Start()
    {
        row = levelDifficulty.row;
        col = levelDifficulty.column;

        OnLevelStartEventArgs e = new OnLevelStartEventArgs();
        e.brickCount = row * col;

        OnLevelStart?.Invoke(this, e);

        if (brickPrefab == null) return;
        _spaceX = brickPrefab.gameObject.transform.localScale.x * 5; // 7.5
        _spaceY = brickPrefab.gameObject.transform.localScale.y * 10; // 5

        InitializeGrid();
        PlacePrefabs();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                float xPos = startPos.x + (j * _spaceX);
                float yPos = startPos.y - (i * _spaceY);
                _gridList.Add(new Vector2(xPos, yPos));
            }
        }
    }

    private void PlacePrefabs()
    {
        for (int i = 0; i < _gridList.Count; i++) 
        {
            Vector3 spawnPos = new Vector3(_gridList[i].x, _gridList[i].y, 0);
            Instantiate(brickPrefab, spawnPos, Quaternion.identity);
        }
    }
}
