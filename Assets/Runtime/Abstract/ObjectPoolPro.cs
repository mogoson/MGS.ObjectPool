/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ObjectPoolPro.cs
 *  Description  :  Object pool pro.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ObjectPool
{
    /// <summary>
    /// Object pool for resettable object.
    /// </summary>
    /// <typeparam name="T">Specified type of object.</typeparam>
    public class ObjectPoolPro<T> : ObjectPool<T>, IObjectPoolPro<T> where T : IRecyclable, new()
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="capacity">Capacity of object pool.</param>
        public ObjectPoolPro(int capacity = 25) : base(capacity) { }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <returns></returns>
        protected override T Create()
        {
            return new T();
        }

        /// <summary>
        /// Reset this object.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Reset(T obj)
        {
            obj.Resete();
        }

        /// <summary>
        /// Dispose this object.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Dispose(T obj)
        {
            obj.Dispose();
        }
    }
}