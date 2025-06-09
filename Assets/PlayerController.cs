using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Tilemap dangerTilemap;
    public float moveAmount = 1f;

    private bool canMove = false;
    private bool hasMoved = false;

    void Start()
    {
        StartCoroutine(UnlockMovementAfterDelay());
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    void Update()
    {
        if (!canMove) return;

        Vector3 move = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W)) { move.y += moveAmount; hasMoved = true; }
        if (Input.GetKeyDown(KeyCode.S)) { move.y -= moveAmount; hasMoved = true; }
        if (Input.GetKeyDown(KeyCode.A)) { move.x -= moveAmount; hasMoved = true; }
        if (Input.GetKeyDown(KeyCode.D)) { move.x += moveAmount; hasMoved = true; }

        Vector3 newPos = transform.position + move;

        // Round to whole numbers to match monster grid positions
        Vector2 checkPos = new Vector2(Mathf.Round(newPos.x), Mathf.Round(newPos.y));

        // Check for Game Over
        if (MonsterSpawner.monsterPositions != null)
        {
            foreach (Vector2 pos in MonsterSpawner.monsterPositions)
            {
                if (pos == checkPos)
                {
                    FindFirstObjectByType<GameManager>().GameOver();
                    return;
                }
            }
        }

        // ✅ Win only if player has moved and is on the goal tile
        if (hasMoved && Vector2.Distance(newPos, MonsterSpawner.goalPosition) < 0.1f)
        {
            FindFirstObjectByType<GameManager>().Win();
            return;
        }

        transform.position = newPos;

        Vector3Int tilePos = dangerTilemap.WorldToCell(transform.position);
        if (dangerTilemap.HasTile(tilePos))
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal") && hasMoved)
        {
            FindFirstObjectByType<GameManager>().Win();
        }
        /*
        // Nowe: przegrana po uderzeniu w tilemapę
        if (other.GetComponent<TilemapCollider2D>())
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }*/
    }

    private IEnumerator UnlockMovementAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

}
