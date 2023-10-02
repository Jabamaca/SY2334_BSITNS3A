using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TEST");
    }


    private void OnEnable()
    {
        Debug.Log("KEEP TRACK");
    }

    private void OnDisable()
    {
        Debug.Log("LOOSE TRACK");
    }

    private void OnDestroy()
    {
        Debug.Log("DESTROY");
    }

    private int counter = 0;
    [SerializeField]
    private float WalkSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        float transition = Time.deltaTime * WalkSpeed;
        Vector3 vec = new Vector3(0f, transition, 0f);
        transform.localPosition += vec;
    }
}
