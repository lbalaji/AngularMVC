using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AngularJSAuthentication.API.Entities;

namespace AngularJSAuthentication.API
{
    public interface ICalculatorRepositary
    {
        IEnumerable<Calculator> GetCalculations();
        Task<Calculator> GetCalculationById(string calcId);
        void InsertCalculation(Calculator calculation);
        Task<bool> DeleteCalculation(string calcId);
        void UpdateCalculation(Calculator calculation);
    }
}