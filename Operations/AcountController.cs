using ATM.Data;
using ATM.Entites;

namespace ATM.Operations
{
    public class AcountController
    {
        InMemory inMemory = new InMemory();
        public bool controller(int tcno, int password)
        {
            User user = inMemory.Get(tcno);
            if (user.Password == password)
                 { return true; }
            else { return false; }
        }
    }
}
