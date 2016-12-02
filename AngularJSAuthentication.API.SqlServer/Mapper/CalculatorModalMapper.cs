using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Entities
{
    internal static class CalculatorModalMapper
    {
        internal static CalculatorModal ToModal (this Calculator t)
        {
            return t == null ? null :
                new CalculatorModal()
                {
                    Id = t.Id,
                    Number1 = t.Number1,
                    Number2 = t.Number2,
                    Result = t.Result,
                    Username = t.Username,
                    OperationType = t.OperationType,
                    Name = t.Name
                };
        }
    }
}