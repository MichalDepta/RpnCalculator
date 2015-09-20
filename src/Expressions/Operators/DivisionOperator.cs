namespace Expressions.Operators
{
    public class DivisionOperator : Operator
    {
        public override Argument CalculateResult(Argument arg1, Argument arg2)
        {
            return new Argument(arg1.Value / arg2.Value);
        }

        protected override string GetStringRepresentation() => "/";
    }
}
