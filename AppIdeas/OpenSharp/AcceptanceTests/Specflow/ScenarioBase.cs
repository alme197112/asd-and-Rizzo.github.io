using System;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Helpers
{
    /// <summary>
    /// Contains shorthand for usage of <see cref="ScenarioContext"/>.
    /// </summary>
    public class ScenarioBase
    {
        public T Get<T>() where T : class
        {
            return ScenarioContext.Current.Get<T>();
        }

        public T Get<T>(string id) where T : class
        {
            return ScenarioContext.Current.Get<T>(id);
        }

        public void Set<T>(T data) where T : class
        {
            ScenarioContext.Current.Set(data);
        }

        public void Set<T>(T data,string id) where T : class
        {
            ScenarioContext.Current.Set(data,id);
        }

        public void Set<T>(Expression<Func<T>> dataExpression) where T : class
        {
            var member = (MemberExpression) (dataExpression.Body);
            ScenarioContext.Current.Set(dataExpression.Compile().Invoke(), member.Member.Name);
        }

    }
}
