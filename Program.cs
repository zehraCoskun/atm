using ATM.Data;
using ATM.Entites;
using ATM.Operations;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hoşgeldiniz, lütfen TC Kimlik Numaranızı giriniz");
        int tcnoInput = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Lütfen şifrenizi giriniz");
        int pwInput = Convert.ToInt32(Console.ReadLine());

        AcountController acountController = new AcountController();
        InMemory inMemory = new InMemory();
        bool controller = acountController.controller(tcnoInput, pwInput);
        if (controller is true)
        {   begin:
            Console.WriteLine("Hoşgeldiniz, yapmak istediğiniz işlemi seçiniz \nPara yatırmak için 1 \nPara çekmek için 2 \nBakiyenizi görüntülemek için 3'e");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Yatırmak istediğiniz tutarı giriniz");
                int count = Convert.ToInt32(Console.ReadLine());
                User user = inMemory.Get(tcnoInput);
                int newBalance = user.Balance + count;
                System.Console.WriteLine("Güncel bakiyeniz : " + newBalance);
                inMemory.UpdateBalance(tcnoInput, newBalance);
                goto begin;
            }
            else if (choice == 2)
            {
                Console.WriteLine("Çekmek istediğiniz tutarı giriniz");
                int count = Convert.ToInt32(Console.ReadLine());
                User user = inMemory.Get(tcnoInput);
                if (user.Balance >= count)
                {
                    int newBalance = user.Balance - count;
                    System.Console.WriteLine("Güncel bakiyeniz : " + newBalance);
                    inMemory.UpdateBalance(tcnoInput, newBalance);
                    goto begin;
                }
                else
                {
                    System.Console.WriteLine("Bakiyeniz yetersiz");
                    goto begin;
                }
            }
            else if (choice == 3)
            {
                User user = inMemory.Get(tcnoInput);
                Console.WriteLine("Bakiyeniz : " + user.Balance);
                goto begin;
            }
        }
    }
}