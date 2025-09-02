/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IGoPool.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/02/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ObjectPool
{
    public interface IGoPool : IObjectPool<GameObject>
    {
        T Take<T>();
    }
}