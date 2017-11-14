
using ex1.Data;
using ex1.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Ex1WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private DisconnectedData _repo;

        public CompanyController(DisconnectedData repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<int, string>> Get()
        {
            var list = _repo.GetCompanyReferenceList();
            return list;
        }

        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return _repo.LoadCompanyGraph(id);
        }

        //example raw json: {"name":"Julie","secretIdentity":{"realName":"Julia"}}
        [HttpPost]
        public void Post([FromBody] Company value)
        {
            _repo.SaveCompanyGraph(value);
        }
    }
}