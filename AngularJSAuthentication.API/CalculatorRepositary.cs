namespace AngularJSAuthentication.API
{
    using AngularJSAuthentication.API.Entities;
    using AngularJSAuthentication.API.Models;
    using Microsoft.AspNet.Identity;
    using MongoDB.Driver.Builders;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CalculatorRepository : ICalculatorRepositary
    {
        private readonly IMongoContext _mongoContext;
        private readonly ApplicationUserManager userManager;

        public CalculatorRepository(IMongoContext mongoContext)
        {
            this._mongoContext = mongoContext;
        }

        public Task<Calculator> GetCalculationById(string id)
        {
            var query = Query<Calculator>.EQ(r => r.Id, id);

            var calculation = _mongoContext.Calculations.Find(query).SetLimit(1).FirstOrDefault();
            
            return Task.FromResult(calculation);
        }

        public IEnumerable<Calculator> GetCalculations()
        {
            return _mongoContext.Calculations.FindAll().ToList();
        }

        public void InsertCalculation(Calculator calculaton)
        {
            var id = System.Guid.NewGuid().ToString("n");
            calculaton.Id = id;
            var result = _mongoContext.Calculations.Insert(calculaton);
        }

        public void UpdateCalculation(Calculator calculaton)
        {
            DeleteCalculation(calculaton.Id);
            calculaton.Id = calculaton.Id;
            _mongoContext.Calculations.Insert(calculaton);
        }

        public Task<bool> DeleteCalculation(string id)
        {
             var query = Query<Calculator>.EQ(c => c.Id, id);
             _mongoContext.Calculations.Remove(query);
             var writeConcernResult = _mongoContext.Calculations.Remove(query);
             return Task.FromResult(writeConcernResult.DocumentsAffected == 1);
        }
    }
}