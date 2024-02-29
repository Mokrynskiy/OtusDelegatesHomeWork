namespace OtusDelegatesHomeWork
{
    public static class Extentions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> function) where T : class
        {
            T result = collection.FirstOrDefault();
            if (result != null)
            {
                var max = function(result);
                foreach ( var item in collection )
                {
                    var x = function(item);
                    if (max < function(item))
                    {
                        max = x;
                        result = item;
                    }
                }
            }
            return result;
        }
    }
}
