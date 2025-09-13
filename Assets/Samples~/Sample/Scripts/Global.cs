/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Global.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/02/2025
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ObjectPool.Sample
{
    public sealed class Global
    {
        public static IGoPoolManager GoPoolManager { get; }

        static Global()
        {
            GoPoolManager = new GoPoolManager();
        }
    }
}