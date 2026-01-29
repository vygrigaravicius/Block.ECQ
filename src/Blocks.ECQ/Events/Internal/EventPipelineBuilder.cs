using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Blocks.ECQ.Events
{
    internal sealed class EventPipelineBuilder
    {
        private static readonly ConcurrentDictionary<Type,
            Func<IEventPipeline>> _lambdas = [];

        public static IEventPipeline Build(IEvent payload)
            => _lambdas.GetOrAdd(payload.GetType(), AssmebleLambda).Invoke();

        private static Func<IEventPipeline> AssmebleLambda(
            Type typeOfPayload)
        {
            ConstructorInfo? ctor = typeof(EventPipeline<>)
                .MakeGenericType(typeOfPayload)
                .GetConstructors()[0];

            if(ctor is null)
                throw new InvalidOperationException();

            NewExpression newExpression = Expression.New(ctor);

            Expression casting = Expression.Convert(
                newExpression, typeof(IEventPipeline));

            var lambda = Expression.Lambda<Func<IEventPipeline>>(
                casting);

            return lambda.Compile();
        }
    }
}
