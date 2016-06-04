using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

    public List<Sprite> tileSprites = new List<Sprite>();
    public int mapHeight;
    public int mapWidth;
    public GameObject Units;
    public GameObject Buildings;
    public GameObject Tiles;
    public GameObject[] prefabs;
    MapUtil map = new MapUtil();
    System.Random r;

    void OnLevelWasLoaded(int level) {

        int randomPick;
        int height = mapHeight + 2;
        int width = mapWidth + 4;
        r = new System.Random();

        for (float y = 0; y < height; y++) {
            for (float x = 0; x < width; x++) {
                randomPick = r.Next(0, tileSprites.Count - 1);
                if ((x == 1 || x == width - 2) && !(y >= height - 2)) {
                    map.CreateComponent(tileSprites[8], new Vector3(x, y), "Wall (" + x + "," + y + ")", Tiles.transform, "EdgeMap").AddComponent<BoxCollider2D>();
                }
                else if ((y == height - 2) && !(x == 0 || x == width - 1)) {
                    map.CreateComponent(tileSprites[8], new Vector3(x, y), "Wall (" + x + "," + y + ")", Tiles.transform, "EdgeMap").AddComponent<BoxCollider2D>();
                }
                map.CreateComponent(tileSprites[randomPick], new Vector3(x, y), "tile_ " + randomPick + "(" + x + "," + y + ")", transform, "GroundMap");
            }
        }

        BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        bc.size = new Vector3(width, height) / 10;
        bc.offset = bc.size / 2;
    }

    void Start() {
        GameObject obj = prefabByName("GattlingTurret");
        if (obj != null) {
            Debug.Log("Created gattling turret");
        }
        else {
            Debug.Log("Something went wrong");
        }
    }

    public GameObject createBuilding(string prefabName, Vector3 position) {
        GameObject prefab = prefabByName(prefabName);
        Instantiate(prefab);
        return null;
    }

    GameObject prefabByName(string name) {
        GameObject result = null;
        foreach (GameObject obj in prefabs) {
            if (obj.name == name) {
                result = obj;
                break;
            }
        }
        return result;
    }
}
