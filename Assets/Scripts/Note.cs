using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    Rigidbody2D rb;
    public KeyCode key;

    void Awake()
    {
    }
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
    }
}
