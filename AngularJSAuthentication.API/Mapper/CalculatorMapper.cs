using AngularJSAuthentication.API.Entities;

namespace AngularJSAuthentication.API.Models
{
    internal static class CalculatorMapper
    {
        internal static Calculator ToEntity(this CalculatorModal t)
        {
            return t == null
                ? null
                : new Calculator()
                {
                    Id = t.Id,
                    Number1 = t.Number1,
                    Number2 = t.Number2,
                    Result = t.Result,
                    OperationType = t.OperationType,
                    Username = t.Username,
                    Name = t.Name
                };
        }
    }
}