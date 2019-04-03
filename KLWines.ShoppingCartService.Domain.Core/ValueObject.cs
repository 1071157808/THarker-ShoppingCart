using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core
{
    public abstract class ValueObject<TValue> where TValue : IComparable
    {
        public TValue Value { get; protected set; }

        public ValueObject(TValue val){
            Value = val;
        }


        public override bool Equals(object obj)
        {
            var @object = obj as ValueObject<TValue>;
            return @object != null &&
                   EqualityComparer<TValue>.Default.Equals(Value, @object.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<TValue>.Default.GetHashCode(Value);
        }

        public static bool operator ==(ValueObject<TValue> o1, ValueObject<TValue> o2) => o1 != null && o2 != null && o1.Value.Equals(o2.Value);
        public static bool operator !=(ValueObject<TValue> o1, ValueObject<TValue> o2) => !(o1 == o2);
    }
}
