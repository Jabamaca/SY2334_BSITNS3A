using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _CurrentLifeTime = 0f;
    public float LifeTime = 2f;
    public float Speed = 5f;

    public delegate void OnPoolHandling (BulletController poolable);
    public OnPoolHandling OnPool = delegate {
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float t = Time.deltaTime;

        _CurrentLifeTime += t;
        transform.position += new Vector3 (Speed * t, 0f, 0f);

        if (_CurrentLifeTime > LifeTime) {
            PoolObject ();
        }
    }

    public void UnpoolObject () {
        gameObject.SetActive (true);
    }

    public void PoolObject () {
        ResetObject ();
        gameObject.SetActive (false);
        OnPool?.Invoke (this);
    }

    public void ResetObject () {
        _CurrentLifeTime = 0f;
    }

}
