using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
namespace RenderHeads.UnityOmeka.Core.Extensions
{
    /// <summary>
    /// Allows for UnityWeb request to follow async / await pattern instead of using coroutines, which is a lot neater.
    /// This snippet came from:
    /// https://gist.github.com/mattyellen/d63f1f557d08f7254345bff77bfdc8b3
    /// </summary>
    public static class TaskExtension
    {
        public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<object>();
            asyncOp.completed += obj => { tcs.SetResult(null); };
            return ((Task)tcs.Task).GetAwaiter();
        }
    }
}