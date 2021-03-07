using UnityEngine;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GeoTetra.GTCommon.Extensions
{
    public static class AsyncOperationExtensions
    {
        public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            asyncOp.completed += obj => { tcs.SetResult(null); };
            return ((Task)tcs.Task).GetAwaiter();
        }
    }
}