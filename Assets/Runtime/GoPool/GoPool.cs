/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GoPool.cs
 *  Description  :  Define GameObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ObjectPool
{
    /// <summary>
    /// Object pool for GameObject.
    /// </summary>
    public class GoPool : ObjectPool<GameObject>, IGoPool
    {
        /// <summary>
        /// Root of gameobjects.
        /// </summary>
        protected Transform root;

        /// <summary>
        /// Prefab to create clone.
        /// </summary>
        protected GameObject prefab;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="node">Root of gameobjects.</param>
        /// <param name="prefab">Prefab to create clone.</param>
        /// <param name="capacity">Capacity of object pool.</param>
        public GoPool(Transform root, GameObject prefab, int capacity = 25) : base(capacity)
        {
            this.root = root;
            this.prefab = prefab;
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <returns>A gameobject.</returns>
        public override GameObject Take()
        {
            var obj = base.Take();
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Take a gameobject from pool and return the T component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T Take<T>()
        {
            return Take().GetComponent<T>();
        }

        /// <summary>
        /// Dispose pool.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            Object.Destroy(root.gameObject);
            prefab = null;
        }

        /// <summary>
        /// Create new gameobject.
        /// </summary>
        /// <returns></returns>
        protected override GameObject Create()
        {
            var clone = Object.Instantiate(prefab);
            clone.transform.parent = root;
            return clone;
        }

        /// <summary>
        /// Reset the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Reset(GameObject obj)
        {
            ResetGameObject(obj);
            ResetComponents(obj);
        }

        /// <summary>
        /// Dispose the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Dispose(GameObject obj)
        {
            Object.Destroy(obj);
        }

        /// <summary>
        /// Reset the gameobject properties.
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void ResetGameObject(GameObject obj)
        {
            obj.SetActive(false);

            obj.tag = prefab.tag;
            obj.layer = prefab.layer;

            obj.transform.position = prefab.transform.position;
            obj.transform.rotation = prefab.transform.rotation;

            obj.transform.parent = null;
            obj.transform.localScale = prefab.transform.localScale;
            obj.transform.parent = root;
        }

        /// <summary>
        /// Reset the gameobject components.
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void ResetComponents(GameObject obj)
        {
            var cpnts = obj.GetComponents<IResettable>();
            foreach (var cpnt in cpnts)
            {
                cpnt.Resete();
            }
        }
    }
}