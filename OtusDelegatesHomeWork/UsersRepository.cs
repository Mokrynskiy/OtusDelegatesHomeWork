namespace OtusDelegatesHomeWork
{
    internal class UsersRepository
    {
        public List<UserModel> GetUsers()
        {
            return new List<UserModel>
            {
                new UserModel {Id = 1, Name ="Иван", Surname = "Иванов", Age = 22},
                new UserModel {Id = 2, Name ="Александр", Surname = "Петров", Age = 45},
                new UserModel {Id = 3, Name ="Павел", Surname = "Терещенко", Age = 36},
                new UserModel {Id = 4, Name ="Егор", Surname = "Герасимов", Age = 54},
                new UserModel {Id = 5, Name ="Степан", Surname = "Ковалев", Age = 28},
                new UserModel {Id = 6, Name ="Алексей", Surname = "Красновский", Age = 32}
            };
        }
    }
}
