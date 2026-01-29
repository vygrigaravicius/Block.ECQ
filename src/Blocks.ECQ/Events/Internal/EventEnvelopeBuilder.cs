using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Blocks.ECQ.Events
{
    internal static class EventEnvelopeBuilder
    {
        private static readonly ConcurrentDictionary<Type,
            Func<IEvent, IEventContext, IEventEnvelope>> _lambdas = [];

        public static IEventEnvelope Build(IEvent payload, IEventContext contrext)
            => _lambdas.GetOrAdd(payload.GetType(), AssembleLambda).Invoke(payload, contrext);

        private static Func<IEvent, IEventContext, IEventEnvelope> AssembleLambda(
            Type typeOfPayload)
        {
            MethodInfo? wrapMethod = typeof(EventEnvelope<>)
                .MakeGenericType(typeOfPayload)
                .GetMethod("Wrap", BindingFlags.Static | BindingFlags.NonPublic);

            if (wrapMethod is null)
                throw new ArgumentNullException();

            ParameterExpression eventParam = Expression.Parameter(typeof(IEvent), "@event");
            ParameterExpression contextParam = Expression.Parameter(typeof(IEventContext), "context");

            MethodCallExpression builder = Expression.Call(wrapMethod,
                Expression.Convert(eventParam, typeOfPayload),
                contextParam);

            Expression casting = Expression.Convert(builder, typeof(IEventEnvelope));

            var lambda = Expression.Lambda<Func<IEvent, IEventContext, IEventEnvelope>>(
                    casting, eventParam, contextParam);

            return lambda.Compile();
        }
    }
}
