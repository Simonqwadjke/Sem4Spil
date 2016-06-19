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
                    MapUtil.CreateComponent(tileSprites[8], new Vector3(x, y), "Wall (" + x + "," + y + ")", Tiles.transform, "EdgeMap").AddComponent<BoxCollider2D>();
                }
                else if ((y == height - 2) && !(x == 0 || x == width - 1)) {
                    MapUtil.CreateComponent(tileSprites[8], new Vector3(x, y), "Wall (" + x + "," + y + ")", Tiles.transform, "EdgeMap").AddComponent<BoxCollider2D>();
                }
                MapUtil.CreateComponent(tileSprites[randomPick], new Vector3(x, y), "tile_" + randomPick + "(" + x + "," + y + ")", transform, "GroundMap");
            }
        }

        BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        bc.size = new Vector3(width, height);
        bc.offset = bc.size / 2;
    }

    void Start() {
        //ModelLayer.Buildings.Defense.GatlingTurret source = demo();

        //GameObject gObj = createBuilding("GatlingTurret");
        //gObj.GetComponent<GatlingTurretBehavior>().source = source;
        //gObj.GetComponent<GatlingTurretBehavior>().Init();
    }

    ModelLayer.Buildings.Defense.GatlingTurret demo() {

        ModelLayer.Buildings.Defense.GatlingTurret source = new ModelLayer.Buildings.Defense.GatlingTurret();

        source.Range = 5;
        source.Location = new ModelLayer.Location() {
            X = 0,
            Y = 0
        };
        source.Size = new ModelLayer.Size() {
            Height = 3,
            Width = 3
        };
        return source;
    }

    public GameObject createBuilding(string prefabName) {
        GameObject prefab = prefabByName(prefabName);
        GameObject gObj = Instantiate(prefab);
        

        gObj.transform.localScale = new Vector3(10, 10);
        gObj.transform.parent = Buildings.transform;
        gObj.tag = "Building";
        gObj.name = prefabName;

        return gObj;
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
