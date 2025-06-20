using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject goalPrefab;
    public Tilemap groundTilemap;  // walkable tiles
    public Tilemap wallTilemap;    // danger/wall tiles
    public Transform player;

    public int numberOfMonsters = 5;
    public static List<Vector2> monsterPositions = new List<Vector2>();
    public static Vector2 goalPosition;

    private List<Vector2> validPositions = new List<Vector2>();

    void Start()
    {
        CacheWalkableTiles();
        SpawnMonsters();
        SpawnGoal();
    }

    void CacheWalkableTiles()
    {
        validPositions.Clear();

        BoundsInt bounds = groundTilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (groundTilemap.HasTile(pos) && !wallTilemap.HasTile(pos))
            {
                Vector2 worldPos = groundTilemap.CellToWorld(pos);
                worldPos.x = Mathf.Round(worldPos.x);
                worldPos.y = Mathf.Round(worldPos.y);
                validPositions.Add(worldPos);
            }
        }
    }

    void SpawnMonsters()
    {
        monsterPositions.Clear();

        for (int i = 0; i < numberOfMonsters; i++)
        {
            Vector2 spawnPos = GetValidSpawnPosition(avoidPlayer: true);
            Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
            monsterPositions.Add(spawnPos);
        }
    }

    void SpawnGoal()
    {
        goalPosition = GetValidSpawnPosition(avoidPlayer: true, avoidMonsters: true);
        Instantiate(goalPrefab, goalPosition, Quaternion.identity);
    }

    Vector2 GetValidSpawnPosition(bool avoidPlayer = false, bool avoidMonsters = false)
    {
        int safetyLimit = 1000;
        while (safetyLimit-- > 0)
        {
            Vector2 pos = validPositions[Random.Range(0, validPositions.Count)];

            if (avoidPlayer && Vector2.Distance(pos, player.position) < 1f) continue;
            if (avoidMonsters && monsterPositions.Contains(pos)) continue;

            return pos;
        }

        Debug.LogWarning("Could not find valid spawn position");
        return Vector2.zero;
    }
}
