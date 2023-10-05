using GradesProjectFB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using users;
using static GradesProjectFB.Dto;

namespace GradesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly List<GradesDto> grades = new List<GradesDto>();
        Connect connect = new Connect();
        [HttpGet]
        public ActionResult<IEnumerable<GradesDto>> Get()
        {
            try
            {
                connect.connection.Open();
                string sql = "SELECT * FROM `grades`";
                MySqlCommand command = new MySqlCommand(sql, connect.connection);
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new GradesDto(
                        reader.GetGuid(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    );
                    grades.Add(item);
                }
                connect.connection.Close();
                return StatusCode(200, grades);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<GradesDto> Get(Guid Id)
        {
            try
            {
                connect.connection.Open();
                string sql = $"SELECT * FROM users WHERE Id={Id}";
                MySqlCommand command = new MySqlCommand(sql, connect.connection);
                command.ExecuteNonQuery();
                connect.connection.Close();
                return StatusCode(200, grades);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<GradesDto> Post(CreateGrade createGrade)
        {
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            var grade = new Grade
            {
                Id = Guid.NewGuid(),
                Grades = createGrade.Grades,
                Description = createGrade.Description,
                Created = time
            };
            try
            {
                connect.connection.Open();
                string sql = $"INSERT INTO `grades`(`Id`, `Grades`, `Description`, `Created`) VALUES ('{grade.Id}','{grade.Grades}','{grade.Description}','{grade.Created}')";
                MySqlCommand command = new MySqlCommand(sql, connect.connection);
                command.ExecuteNonQuery();
                connect.connection.Close();
                return StatusCode(201, grade);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
