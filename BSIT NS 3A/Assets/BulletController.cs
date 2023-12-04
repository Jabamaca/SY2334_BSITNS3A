using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _CurrentLifeTime = 0f;
    public float LifeTime = 2f;
    public float Speed = 5f;

    [SerializeField]
    private Rigidbody2D _RigidBody;

    public delegate void OnPoolHandling (BulletController poolable);
    public OnPoolHandling OnPool = delegate {
    };

    private bool _Bounced = false;

    private void OnCollisionEnter2D (Collision2D collision) {
        // PoolObject ();
        _Bounced = true;

    }

    private void OnCollisionStay2D (Collision2D collision) {

    }

    private void OnCollisionExit2D (Collision2D collision) {
        Debug.Log ("EXITED");
    }

    // Update is called once per frame
    void Update() {
        float t = Time.deltaTime;

        _CurrentLifeTime += t;

        _RigidBody.velocity = new Vector2 (_Bounced ? -Speed : Speed, 0f);

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
        _Bounced = false;
    }

}
