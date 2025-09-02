/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IGoPoolManager.cs
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
    public interface IGoPoolManager
    {
        IGoPool CreatePool(string name, GameObject prefab, int capacity = 25);

        IGoPool FindPool(string name);

        void DeletePool(string name);

        void DeletePools();
    }
}