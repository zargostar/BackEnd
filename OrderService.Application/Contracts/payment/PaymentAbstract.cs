using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts.payment
{
    public interface PaymentAbstract
    {
       void Payment(int amount);
    }
    public class BankMelat : PaymentAbstract
    {
        public  void Payment(int amount)
        {
            Console.WriteLine("bank melat");
        }
    }  public class BankMelli : PaymentAbstract
    {
        public  void Payment(int amount)
        {
            Console.WriteLine("bank meli");
        }
    }
    public class PaymentFactory
    {
        public static PaymentAbstract BankSelector (PaymentType paymentType)
        {
            PaymentAbstract objectType = null;
            switch (paymentType)
            {
                case PaymentType.bankMelli:
                    objectType= new BankMelli();
                    break;
                   
                case PaymentType.bankMellat:
                    objectType = new BankMelat();
                    break;
            
            }
            return objectType;
        }


    }
    public enum PaymentType
    {
        bankMelli,
        bankMellat,
       
    }
}
