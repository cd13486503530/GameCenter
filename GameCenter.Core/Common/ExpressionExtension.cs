using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Common
{
    public class ExpressionExtension<T>
    {
        public static Expression GenExpre(ParameterExpression param,string property, object proValue)
        {
             
            Expression selector = Expression.Property(param, typeof(T).GetProperty(property));
            Expression right = Expression.Constant(proValue);
            Expression filter = Expression.Equal(selector, right);
            return filter;
        }
    }
}
