using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healthware.Server.Authorization;
using Healthware.Server.Data;
using Healthware.Server.Repositories;
using Healthware.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Healthware.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[HandleAuthorize]
    [Authorize("JwtBearer")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            await _patientRepository.Add(patient);
            return CreatedAtAction("GetPatientById", new {id = patient.PatientId}, patient);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _patientRepository.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            await _patientRepository.Update(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepository.Delete(id);

            return NoContent();
        }
    }
}