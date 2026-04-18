using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private GameObject brick_0Prefab;
    [SerializeField] private Vector2 startPos = new Vector2(-40, 20);

    public int row = 5;
    public int col = 17;

    private float _spaceX;
    private float _spaceY;
    private List<Vector2> _gridList = new List<Vector2>();

    private void Start()
    {
        if (brick_0Prefab == null) return;
        _spaceX = brick_0Prefab.gameObject.transform.localScale.x * 5; // 7.5
        _spaceY = brick_0Prefab.gameObject.transform.localScale.y * 10; // 5
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitializeGrid();
            PlacePrefabs();
        }
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
            Instantiate(brick_0Prefab, spawnPos, Quaternion.identity);
        }
    }
}
