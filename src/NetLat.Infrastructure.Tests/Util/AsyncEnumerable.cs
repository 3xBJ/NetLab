namespace NetLab.Infrastructure.Tests.Util
{
    internal static class AsyncEnumerable
    {
        internal static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> source)
        {
            foreach(T item in source)
            {
                yield return item;
            }

            await Task.CompletedTask;
        }
    }
}
