using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadMap : MonoBehaviour {

    public List<Sprite> list = new List<Sprite>();
    public int mapHeight;
    public int mapWidth;
    Map map = new Map();

    System.Random r;

    void OnLevelWasLoaded(int level) {
        int i;
        int height = mapHeight + 2;
        int width = mapWidth + 4;
        r = new System.Random();

        for(float y = 0; y < height; y++) {
            for(float x = 0; x < width; x++) {
                i = r.Next(0, list.Count- 1);

                if((x == 1 || x == width - 2) && !(y >= height - 2)) {
                    map.CreateComponent(list[8], new Vector3(x, y), "Wall (" + x + "," + y + ")", transform, "EdgeMap").AddComponent<BoxCollider2D>();
                }
                else if((y == height - 2) && !(x == 0 || x == width - 1)) {
                    map.CreateComponent(list[8], new Vector3(x, y), "Wall (" + x + "," + y + ")", transform, "EdgeMap").AddComponent<BoxCollider2D>();
                }

                map.CreateComponent(list[i], new Vector3(x, y), "tile_ " + i + "(" + x + "," + y + ")", transform, "GroundMap");
            }
        }
        BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>();

        bc.isTrigger = true;
        bc.size = new Vector3(width, height) / 10;
        bc.offset = bc.size / 2;
        //bc.size = new Vector3(width, height)/10;
        
        //bc.bounds.center = bc.size/2;
    }
}
