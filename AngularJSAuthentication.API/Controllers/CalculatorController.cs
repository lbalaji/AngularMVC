using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using AngularJSAuthentication.API.Entities;
using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/calculator")]
    public class CalculatorController : ApiController
    {
      

        private readonly CalculatorRepository calcRepository = null;
        private string username ;

        public CalculatorController(CalculatorRepository calcRepository)
        {
            this.calcRepository = calcRepository;
            this.username = base.ControllerContext.RequestContext.Principal.Identity.Name;
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new CalculatorModal());
        }

        [Authorize]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(string id)
        {
            var result = await calcRepository.GetCalculationById(id);
            if (result != null)
                return Ok(result.ToModal());
            return BadRequest();
        }

        [Authorize]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await calcRepository.DeleteCalculation(id);
            return Ok();
        }

        [Route("Operations")]
        public  IHttpActionResult Operations()
        {
            return Ok( Operation.CreateOperations());
        }


    
        [Route("calculatons")]
        [HttpGet]
        public IHttpActionResult Calculatons()
        {
            return Ok(calcRepository.GetCalculations());
        }

         
        [Authorize]
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Save(CalculatorModal calculatorModal)
        {
            if (calculatorModal == null|| !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            calculatorModal = await Calculate(calculatorModal);
            if (calculatorModal.Id == null)
            {
                calculatorModal.Username = username;
                calcRepository.InsertCalculation(calculatorModal.ToEntity()); 
            }
            else
            {
                calcRepository.UpdateCalculation(calculatorModal.ToEntity()); 
            } 
           
            return Ok(calculatorModal);
        }

        [Authorize]
        [Route("Calculate")]
        [HttpPost]
        public async Task<CalculatorModal> Calculate(CalculatorModal calculatorModel)
        {
            if (calculatorModel.OperationType == OperationTypes.Add)
                calculatorModel.Result =  MathsHelper.Add(calculatorModel.Number1, calculatorModel.Number2);
            if (calculatorModel.OperationType == OperationTypes.Substract)
                calculatorModel.Result = MathsHelper.sub(calculatorModel.Number1 , calculatorModel.Number2);
            if (calculatorModel.OperationType == OperationTypes.Divide)
                calculatorModel.Result =  MathsHelper.div(calculatorModel.Number1 , calculatorModel.Number2);
            return calculatorModel;
        }

        //private IHttpActionResult GetErrorResult(bool result)
        //{
        //    if (result == null)
        //    {
        //        return InternalServerError();
        //    }

        //    if (!result.Succeeded)
        //    {
        //        if (result.Errors != null)
        //        {
        //            foreach (string error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error);
        //            }
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            // No ModelState errors are available to send, so just return an empty BadRequest.
        //            return BadRequest();
        //        }

        //        return BadRequest(ModelState);
        //    }

        //    return null;
        //}
    }
     
     #region Helpers

    public class Operation
    {
        public string Name { get; set; }
        public OperationTypes OperationType { get; set; }

        public static List<Operation> CreateOperations()
        {
            var OperationList = new List<Operation>
            {
                new Operation { Name = "Add", OperationType = OperationTypes.Add},
                new Operation { Name = "Substract", OperationType = OperationTypes.Substract},
                new Operation { Name = "Division", OperationType = OperationTypes.Divide}
            };

            return OperationList;
        }
    }
    #endregion
}
