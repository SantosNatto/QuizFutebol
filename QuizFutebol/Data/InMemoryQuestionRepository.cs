using QuizFutebol.Models;

namespace QuizFutebol.Data
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly List<Question> _questions = new()
{
    new Question
    {
        Id = 1,
        Text = "Quem é o maior artilheiro da Seleção Brasileira?",
        Options = new() { "Pelé", "Neymar", "Romário", "Ronaldo" },
        CorrectIndex = 1
    },
    new Question
    {
        Id = 2,
        Text = "Qual clube venceu a Libertadores de 2022?",
        Options = new() { "Flamengo", "Palmeiras", "Athletico-PR", "River Plate" },
        CorrectIndex = 0
    },
    new Question
    {
        Id = 3,
        Text = "Em que país ocorreu a Copa do Mundo de 2014?",
        Options = new() { "África do Sul", "Rússia", "Brasil", "Alemanha" },
        CorrectIndex = 2
    },
    new Question
    {
        Id = 4,
        Text = "Quantos jogadores um time tem em campo no futebol?",
        Options = new() { "9", "10", "11", "12" },
        CorrectIndex = 2
    },
    new Question
    {
        Id = 5,
        Text = "Quem ganhou a Bola de Ouro em 2023?",
        Options = new() { "Messi", "Neymar", "Mbappé", "Cristiano Ronaldo" },
        CorrectIndex = 0
    },
    new Question
    {
        Id = 6,
        Text = "Qual time brasileiro tem mais títulos da Copa do Brasil?",
        Options = new() { "Flamengo", "Cruzeiro", "Palmeiras", "Grêmio" },
        CorrectIndex = 1
    },
    new Question
    {
        Id = 7,
        Text = "Qual país venceu a Copa do Mundo de 2018?",
        Options = new() { "Alemanha", "França", "Brasil", "Croácia" },
        CorrectIndex = 1
    },
    new Question
    {
        Id = 8,
        Text = "Quem é conhecido como 'Fenômeno' no futebol?",
        Options = new() { "Ronaldo Nazário", "Ronaldinho", "Pelé", "Romário" },
        CorrectIndex = 0
    },
    new Question
    {
        Id = 9,
        Text = "Qual jogador marcou o gol do título da Copa do Mundo de 1994 para o Brasil?",
        Options = new() { "Romário", "Bebeto", "Rai", "Dunga" },
        CorrectIndex = 3
    },
    new Question
    {
        Id = 10,
        Text = "Qual estádio é conhecido como 'Maracanã'?",
        Options = new() { "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Brasília" },
        CorrectIndex = 1
    }
};


        public IReadOnlyList<Question> GetAll() => _questions;

        public Question? GetById(int id) =>
            _questions.FirstOrDefault(q => q.Id == id);
    }
}
