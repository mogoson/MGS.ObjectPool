/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ObjectPool.cs
 *  Description  :  Define ObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.ObjectPool
{
    /// <summary>
    /// Object pool for specified type T.
    /// </summary>
    /// <typeparam name="T">Specified type of object.</typeparam>
    public abstract class ObjectPool<T> : IObjectPool<T>
    {
        /// <summary>
        /// Capacity of object pool.
        /// </summary>
        public int Capacity { set; get; }

        /// <summary>
        /// Current reserve of objects in pool.
        /// </summary>
        public int Reserve { get { return objectStack.Count; } }

        /// <summary>
        /// Stack store objects.
        /// </summary>
        protected Stack<T> objectStack = new Stack<T>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="capacity">Capacity of object pool.</param>
        public ObjectPool(int capacity = 25)
        {
            Capacity = capacity;
        }

        /// <summary>
        /// Take a object from pool.
        /// </summary>
        /// <returns>A object.</returns>
        public virtual T Take()
        {
            if (objectStack.Count > 0)
            {
                return objectStack.Pop();
            }
            return Create();
        }

        /// <summary>
        /// Recycle object to pool.
        /// </summary>
        /// <param name="obj">Object to recycle.</param>
        public virtual void Recycle(T obj)
        {
            //Null object do not need to recycle.
            if (obj == null)
            {
                return;
            }

            //Avoid repeated recycle. 
            if (objectStack.Contains(obj))
            {
                return;
            }

            if (objectStack.Count < Capacity)
            {
                Reset(obj);
                objectStack.Push(obj);
            }
            else
            {
                Dispose(obj);
            }
        }

        /// <summary>
        /// Clear all objects.
        /// </summary>
        public virtual void Clear()
        {
            foreach (var obj in objectStack)
            {
                Dispose(obj);
            }
            objectStack.Clear();
        }

        /// <summary>
        /// Dispose pool.
        /// </summary>
        public virtual void Dispose()
        {
            Clear();
            objectStack = null;
        }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <returns></returns>
        protected abstract T Create();

        /// <summary>
        /// Reset this object.
        /// </summary>
        /// <param name="obj"></param>
        protected abstract void Reset(T obj);

        /// <summary>
        /// Dispose this object.
        /// </summary>
        /// <param name="obj"></param>
        protected abstract void Dispose(T obj);
    }
}