using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    public TileBase[] closedDoorTiles; // Array of tiles for the closed door
    public TileBase[] openDoorTiles;   // Array of tiles for the open door
    private Tilemap tilemap;

    public Vector3Int[] doorTilePositions; // The positions of the door tiles in the Tilemap grid.

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void OpenDoor()
    {
        for (int i = 0; i < doorTilePositions.Length; i++)
        {
            tilemap.SetTile(doorTilePositions[i], openDoorTiles[i]);
        }
    }
}


