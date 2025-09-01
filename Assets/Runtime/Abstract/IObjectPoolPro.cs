/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IObjectPoolPro.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/30
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ObjectPool
{
    public interface IObjectPoolPro<T> : IObjectPool<T> where T : IRecyclable { }
}