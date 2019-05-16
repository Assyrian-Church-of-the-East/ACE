using System;

namespace Isg.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static T ThrowExceptionIfReturnValueIsNull<T>(this T item, Type objectType)
        {
            if(item == null)
            {
                throw new NullReferenceException($"The object can not be null! object type is {objectType}");
            }
            return item;
        }
    }
}
