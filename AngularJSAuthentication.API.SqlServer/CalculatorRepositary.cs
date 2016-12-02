using System;

namespace AngularJSAuthentication.API
{
    using AngularJSAuthentication.API.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CalculatorRepository : IDisposable
    {
        private readonly AuthContext _sqlContext;
       

        public CalculatorRepository()
        {
            this._sqlContext = new AuthContext();
        }

        public Task<Calculator> GetCalculationById(string id)
        {

            var calculation = _sqlContext.Calculator.Where(r => r.Id == id).SingleOrDefault();
            
            return Task.FromResult(calculation);
        }

        public IEnumerable<Calculator> GetCalculations(string username)
        {
            return _sqlContext.Calculator.Where(t=>t.Username==username).ToList();
        }

        public void InsertCalculation(Calculator calculaton)
        {
            var id = System.Guid.NewGuid().ToString("n");
            calculaton.Id = id;
             _sqlContext.Calculator.Add(calculaton);
            _sqlContext.SaveChanges();
        }

        public void UpdateCalculation(Calculator calculaton)
        {
            DeleteCalculation(calculaton.Id);
            calculaton.Id = calculaton.Id;
            _sqlContext.Calculator.Add(calculaton);
            _sqlContext.SaveChanges();
        }

        public bool DeleteCalculation(string id)
        {
            

             var calculation =   _sqlContext.Calculator.Find(id);

             if (calculation != null)
             {
                 _sqlContext.Calculator.Remove(calculation);
                 return _sqlContext.SaveChanges() > 0;
             }

             return false;

        }

        public void Dispose()
        {
            _sqlContext.Dispose(); 

        }
    }
}