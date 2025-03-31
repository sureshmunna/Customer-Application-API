using CustomerAplli.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAplli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MembershipDBContext _MemContext;
        public CustomerController(MembershipDBContext context)
        {
            _MemContext = context;
        }
        // GET: api/<CustomerController>
        MembershipDBContext context = new MembershipDBContext();
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return Ok(_MemContext.Customer.ToList());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return Ok(_MemContext.Customer.Find(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult post([FromBody]Customer obj)
        {
            // _MemContext.Custome
            Customer x = new Customer();
            x.Name = obj.Name;
            x.Age = obj.Age;
            _MemContext.Customer.Add(x);
            _MemContext.SaveChanges();
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Customer obj)
        {
            //var async=;
            //StringContent requestContent = Request.Body;
            //string jsonContent = requestContent.ReadAsStringAsync().Result;
            // Customer obj = JsonConvert.DeserializeObject<Customer>(jsonContent);
            // ((StringContent)this HttpContent content).ReadAsStringAsync().Result;
            //using var reader = new StreamReader(Request.Body);
            //var body = reader.ReadToEndAsync();
            // Customer data = JsonConvert.DeserializeObject<Customer>(body);


            var data = _MemContext.Customer.Where(temp => temp.Id == id).FirstOrDefault();

            if (data != null)
            {
                data.Name = obj.Name;
                data.Age = obj.Age;
                //_MemContext.Customer.Update(data);
                _MemContext.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _MemContext.SaveChanges();
                return Ok();
            }
            return NotFound();

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = _MemContext.Customer.Where(temp => temp.Id == id).FirstOrDefault();
            if (data != null)
            {
                _MemContext.Customer.Remove(data);
                _MemContext.SaveChanges();

            }

        }
    }
}
