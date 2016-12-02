namespace AngularJSAuthentication.API.Controllers
{
    public class MathsHelper
    {
        public MathsHelper() { }
        public static decimal Add(decimal num1, decimal num2)
        {
            decimal x = num1 + num2;
            return x;
        }

        public static decimal sub(decimal num1, decimal num2)
        {
            decimal x = num1 - num2;
            return x;
        }
        public static decimal div(decimal num1, decimal num2)
        {
            decimal x = num1 / num2;
            return x;
        }
    }
}