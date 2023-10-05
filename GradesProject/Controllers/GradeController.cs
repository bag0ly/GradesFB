using GradesProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using users;
using static GradesProject.Dto;

namespace GradesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly List<GradesDto> grades = new List<GradesDto>();
        Connect connect = new Connect();

    }
}
