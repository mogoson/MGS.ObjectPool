/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IObjectPool.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/30
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.ObjectPool
{
    public interface IObjectPool<T> : IDisposable
    {
        int Capacity { set; get; }

        int Reserve { get; }

        T Take();

        void Recycle(T obj);

        void Clear();
    }
}