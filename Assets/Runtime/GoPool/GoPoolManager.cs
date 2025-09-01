/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GoPoolManager.cs
 *  Description  :  Manager of gameobject pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using MGS.Singleton;
using UnityEngine;

namespace MGS.ObjectPool
{
    /// <summary>
    /// Manager of gameobject pool.
    /// </summary>
    public sealed class GoPoolManager : Singleton<GoPoolManager>
    {
        /// <summary>
        /// Pools infos (name and pool).
        /// </summary>
        private Dictionary<string, GoPool> pools = new Dictionary<string, GoPool>();

        /// <summary>
        /// Root transform for pools.
        /// </summary>
        private readonly Transform root;

        /// <summary>
        /// Constructor.
        /// </summary>
        private GoPoolManager()
        {
            //Create the root for pools.
            root = new GameObject(GetType().Name).transform;
            Object.DontDestroyOnLoad(root);
        }

        /// <summary>
        /// Create a pool in this manager.
        /// </summary>
        /// <param name="name">Name of pool.</param>
        /// <param name="prefab">Prefab of pool.</param>
        /// <param name="capacity">Capacity of object pool.</param>
        /// <returns>Pool created base on parameters.</returns>
        public GoPool CreatePool(string name, GameObject prefab, int capacity = 25)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (pools.ContainsKey(name))
            {
                return pools[name];
            }

            if (prefab == null)
            {
                return null;
            }

            //Create pool root.
            var poolRoot = new GameObject(name).transform;
            poolRoot.parent = root;

            //Create pool.
            var newPool = new GoPool(poolRoot, prefab, capacity);
            pools.Add(name, newPool);
            return newPool;
        }

        /// <summary>
        /// Find GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        /// <returns>Name match GameObjectPool.</returns>
        public GoPool FindPool(string name)
        {
            if (pools.ContainsKey(name))
            {
                return pools[name];
            }
            return null;
        }

        /// <summary>
        /// Delete GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        public void DeletePool(string name)
        {
            if (pools.ContainsKey(name))
            {
                var pool = pools[name];
                pool.Dispose();
                pools.Remove(name);
            }
        }

        /// <summary>
        /// Delete all pool.
        /// </summary>
        public void DeletePools()
        {
            foreach (var pool in pools.Values)
            {
                pool.Dispose();
            }
            pools.Clear();
        }
    }
}