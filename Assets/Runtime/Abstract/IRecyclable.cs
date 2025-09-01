/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IRecyclable.cs
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
    public interface IRecyclable : IResettable, IDisposable { }
}