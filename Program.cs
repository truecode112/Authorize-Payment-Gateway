using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AuthorizePayment.CustomerProfiles;
using AuthorizeNet.Api.Contracts.V1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AuthorizePayment.PaymentTransactions;

namespace AuthorizePayment
{
	internal class Program
	{

		static void prettyPrint(object response)
		{
			var responseStr = JsonConvert.SerializeObject(response);
			string prettyStr;
			prettyStr = JToken.Parse(responseStr).ToString(Formatting.Indented);
			Console.WriteLine(prettyStr);
		}

		static void Main(string[] args)
		{
			ANetApiResponse response;
			var apiLoginId = ConfigurationManager.AppSettings["APILoginID"];
			var transactionKey = ConfigurationManager.AppSettings["TransactionKey"];
			//CreateCustomerProfile.Run(apiLoginId, transactionKey, "test123@gmail.com");

			//Customer Profile ID: 509095077
			//Payment Profile ID: 514650103
			//Shipping Profile ID: 510434233

			var creditCard = new creditCardType
			{
				cardNumber = "4111111111111111",
				expirationDate = "1028"
			};
			//response = UpdateCustomerPaymentProfile.Run(apiLoginId, transactionKey, "509095077", "514650103", creditCard);


			//GetCustomerPaymentProfile.Run(apiLoginId, transactionKey, "509095077", "514650103");

			//CreateCustomerPaymentProfile.Run(apiLoginId, transactionKey, "509095077");

			//GetCustomerPaymentProfile.Run(apiLoginId, transactionKey, "509095077", "514650103");

			//response = ChargeCreditCard.Run(apiLoginId, transactionKey, 100);

			response = ChargeCustomerProfile.Run(apiLoginId, transactionKey, "509095077", "514650103", 100);
			prettyPrint(response);
		}
	}
}
