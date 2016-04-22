using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _lefSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this._lefSpecification = left;
            this._rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return this._lefSpecification.IsSatisfiedBy(candidate)
                && this._rightSpecification.IsSatisfiedBy(candidate);
        }
    }
}
