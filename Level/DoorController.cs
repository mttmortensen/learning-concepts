using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    public TileBase[] closedDoorTiles; // Array of tiles for the closed door
    public TileBase[] openDoorTiles;   // Array of tiles for the open door
    private Tilemap tilemap;

    public List<Vector3Int> doorTilePositions = new List<Vector3Int>(); // The positions of the door tiles in the Tilemap grid.

    public TileBase markerTile;
    public Tilemap doorTilemap;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();


        List<Vector3Int> doorTilePositionsList = new List<Vector3Int>();

        BoundsInt bounds = doorTilemap.cellBounds;
        TileBase[] allTiles = doorTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile == markerTile)
                {
                    doorTilePositionsList.Add(new Vector3Int(x, y, 0));
                    Debug.Log(doorTilePositionsList.Count);
                }
            }
        }


        doorTilePositions = doorTilePositions.OrderByDescending(pos => pos.y).ToList();

    }

    public void OpenDoor()
    {
        for (int i = 0; i < doorTilePositions.Count; i++)
        {
            tilemap.SetTile(doorTilePositions[i], openDoorTiles[i]);
        }

    }
}


