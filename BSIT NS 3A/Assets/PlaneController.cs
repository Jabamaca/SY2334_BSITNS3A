using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField]
    List<int> IntList = new List<int> ();
    [SerializeField]
    Dictionary<string, int> IntDict = new Dictionary<string, int> ();
    [SerializeField]
    private BulletController _Bullet;
    [SerializeField]
    private float _FiringCD = 0.4f;
    [SerializeField]
    private float _CurrentCD = 0f;

    private List<BulletController> _BulletPool = new List<BulletController> ();
    private List<BulletController> _BulletUnpool = new List<BulletController> ();

    // Start is called before the first frame update
    void Start()
    {
        // IntDict.Add ("one", 1);
        IntDict["one"] = 1;
        Debug.Log ("Value = " + IntDict["one"]);

        if (IntDict.TryGetValue ("one", out int value))
            Debug.Log ("Value = " + value);
    }

    // Update is called once per frame
    void Update()
    {

        if (_CurrentCD > 0f)
            _CurrentCD -= Time.deltaTime;

        if (Input.GetKey ("1")) {
            TryFireBullet ();
        }
    }

    private void TryFireBullet () {
        if (_CurrentCD > 0f)
            return;

        GetBullet ();
        _CurrentCD = _FiringCD;
    }

    public BulletController GetBullet () {
        if (_BulletPool.Count > 0) {
            // Unpool recyclable object
            BulletController bullet = _BulletPool[0];
            _BulletPool.RemoveAt (0);
            bullet.UnpoolObject ();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;
            _BulletUnpool.Add (bullet);
        } else {
            BulletController bullet = Instantiate (_Bullet, transform.position, Quaternion.identity);
            bullet.OnPool += PoolBullet;
            bullet.UnpoolObject ();
            _BulletUnpool.Add (bullet);
            return bullet;
        }

        return null;
    }

    private void PoolBullet (BulletController bullet) {
        _BulletUnpool.Remove (bullet);
        _BulletPool.Add (bullet);
    }
}
