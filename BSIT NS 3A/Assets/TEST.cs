using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private int counter = 0;
    [SerializeField]
    private WarriorStats Stats;

    // Update is called once per frame
    void Update()
    {
        bool hold1 = Input.GetKey ("1");
        bool press1 = Input.GetKeyDown ("1");
        bool release1 = Input.GetKeyUp ("1");

        if (release1)
            Debug.Log ("1111111");

        float xAxisInput = Input.GetAxis ("Horizontal");
        float yAxisInput = Input.GetAxis ("Vertical");

        Vector3 dirInput = new Vector3 (xAxisInput, yAxisInput, 0);
        if (dirInput.magnitude > 1f) {
            dirInput = dirInput.normalized;
        }

        Vector3 movement = dirInput * (Stats.MovementSpeed * Time.deltaTime);
        transform.localPosition += movement;
    }
}
