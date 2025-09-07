using QuizFutebol.Models;

namespace QuizFutebol.Data
{
    public interface IQuestionRepository
    {
        IReadOnlyList<Question> GetAll();
        Question? GetById(int id);
    }
}
