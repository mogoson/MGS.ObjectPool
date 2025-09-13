/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Bullet.cs
 *  Description  :  Define bullet for demo.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.ObjectPool.Sample
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour, IResettable
    {
        #region Field and Property
        public float destroyDelay = 3;

        private new Rigidbody rigidbody;
        private IGoPool bulletPool;
        #endregion

        #region Private Method
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            bulletPool = Global.GoPoolManager.FindPool(Gun.POOL_NAME_BULLET);
        }

        private void OnEnable()
        {
            StartCoroutine(DelayDestroy());
        }

        private void OnCollisionEnter(Collision collision)
        {
            bulletPool.Recycle(gameObject);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator DelayDestroy()
        {
            yield return new WaitForSeconds(destroyDelay);
            bulletPool.Recycle(gameObject);
        }
        #endregion

        #region Public Method
        public void AddForce(Vector3 force)
        {
            rigidbody.AddForce(force);
        }

        public void Resete()
        {
            rigidbody.velocity = Vector3.zero;
        }
        #endregion
    }
}