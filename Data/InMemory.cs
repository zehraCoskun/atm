using ATM.Entites;

namespace ATM.Data
{
    public class InMemory
    {
        List <User> users;
        public InMemory()
        {
            users = new List<User>()
            {
                new User{TCNo=12345, Firstname="Emin", Surname="Alper", Password= 123456, Balance=1230},
                new User{TCNo=98765, Firstname="Pelin", Surname="Esmer", Password=335578, Balance=45567},
                new User{TCNo=56677, Firstname="Onur", Surname="Ünlü", Password=989898, Balance=345},
            };
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public User Get(int tcno)
        {
            return users.Find(x=> x.TCNo==tcno);
        }
        public List<User> GetUsers()
        {
            return users;
        }
        public void UpdateBalance(int tcno, int balance)
        {
            User user = users.Find(x=> x.TCNo==tcno);
            user.Balance=balance;
        }

    }
}