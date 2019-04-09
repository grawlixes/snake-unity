using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    // Prefab for food
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    // Start is called before the first frame update
    void Start() {
        // Spawn every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    // Function to be repeated
    void Spawn()
    {
        int x = (int) Random.Range(borderLeft.position.x,
                                   borderRight.position.x);
        int y = (int) Random.Range(borderBottom.position.y,
                                   borderTop.position.y);

        // Instantiate at x, y
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
