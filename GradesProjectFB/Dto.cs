namespace GradesProjectFB 
{
    public class Dto
    {
        public record GradesDto(Guid Id, int Grades, string Description, string Created);
        public record UpdateGrade(int Grades, string Description);
        public record CreateGrade(int Grades, string Description);
        public record DeleteGrade(Guid Id);
    }
}


