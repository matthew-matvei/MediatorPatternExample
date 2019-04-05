using System;

namespace MediatorPatternExample.Extensions
{
    public static class GenericExtensions
    {
        public static T With<T>(this T subject, Action<T> tranform)
        {
            tranform(subject);

            return subject;
        }
    }
}
