using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ioc Container
            CustomerManager customerManager = new CustomerManager(new Customer(),new CarCreditManager());
            customerManager.GiveCredit();
        }
    }
    class CreditManager
    {
        public void Calculate(int creditType)
        {
            //soner qube
            if (creditType == 1) //esnaf
            {

            }
            else if (creditType == 2) //öğretmen
            {

            }
            Console.WriteLine("Hesaplandı");
        }
        public void Save()
        {
            Console.WriteLine("Kredi verildi");
        }
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();

        public virtual void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }

    class TeacherCreditManager :BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
            Console.WriteLine("Öğretmen kredisi hesaplandı");
        }
        public override void Save()
        {
            //
            base.Save();
            //
        }

    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandı");
        }
    }
    class CarCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Araba kredisi hesaplandı");
        }
    }


    //SOLID

    class Customer
    {
        public Customer()
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı.");
        }
        public int Id { get; set; }
        public string City {  get; set; }

    }
    
    class Person : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }
    class Company : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
    //Katmanlı Mimariler
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
            Console.WriteLine("Müşteri kaydedildi : ");
        }
        public void Delete()
        {
            Console.WriteLine("Müşteri sildi : ");
        }
        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }
    }


}