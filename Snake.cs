using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Default moves to right
    Vector2 dir = Vector2.right;
    // Keeps track of tail
    List<Transform> tail = new List<Transform>();
    // State of eating
    bool ate = false;
    // How long to spend before updating each time
    const float UPDATE_TIME = 0.3f;

    public GameObject tailPrefab;

    // Start is called before the first frame update
    void Start() {
        // Move every 300ms
        InvokeRepeating("Move", UPDATE_TIME, UPDATE_TIME);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            dir = Vector2.right;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            dir = -Vector2.up;    // '-up' means 'down'
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            dir = -Vector2.right; // '-right' means 'left'
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            dir = Vector2.up;
        }
    }

    // Movement
    void Move() {
        // Save current location
        Vector2 v = transform.position;

        // Move head into a new direction to create the gap
        transform.Translate(dir);

        if (tail.Count != 0) {
            // Move last to where head is
            tail.Last().position = v;

            // Add last to the front of the list
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count-1);
        }
    }

    // Checking for collisions
    void OnTriggerEnter2D(Collider2D coll) {
        // Did we hit food?
        if (coll.name.StartsWith("FoodPrefab")) {
            ate = true;

            Destroy(coll.gameObject);
        } else {
            // TODO Game over
        }
    }
}
