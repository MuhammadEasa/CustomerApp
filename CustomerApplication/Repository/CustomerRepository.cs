using CustomerApplication.DB;
using CustomerApplication.Interfaces;
using RestSharp;

namespace CustomerApplication.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly RestClient _client;
        private string _url = string.Empty;
        private const string RoutePreFix = "Customer/";

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration.GetSection("AppSettings").GetSection("ApiUrl").Value.ToString();
            _client =new RestClient(new System.Uri(_url));
        }


        public void DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblCustomer> GetAllCustomers()
        {
            var obj = new List<tblCustomer>();
            try
            {
                RestRequest request = new RestRequest(RoutePreFix + "GetAllCustomers", Method.Get) { RequestFormat = DataFormat.Json };
                request.Timeout = int.MaxValue;
                var response = _client.Execute<List<tblCustomer>>(request);

                if (response.StatusDescription != "OK")
                {
                    var errorObj = ((RestResponseBase)(response));
                    Exception ex = new Exception(errorObj.StatusDescription, new Exception(errorObj.Content));
                    throw ex;
                }
                obj = response.Data;
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }

        public tblCustomer GetCustomer(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveCustomer(tblCustomer customer)
        {
            string result = "-1";
            try
            {

                RestRequest request = new RestRequest(RoutePreFix + "AddCustomer", Method.Post) { RequestFormat = DataFormat.Json };
                request.Timeout = int.MaxValue;
                request.AddJsonBody(customer);
                var response = _client.Execute<string>(request);
                if (response.StatusDescription != "OK")
                {
                    var errorObj = ((RestSharp.RestResponseBase)(response));
                    Exception ex = new Exception(errorObj.StatusDescription, new Exception(errorObj.Content));
                    throw ex;
                }
                result = response.Data;
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateCustomer(tblCustomer customer)
        {
            string result = "-1";
            try
            {

                RestRequest request = new RestRequest(RoutePreFix + "UpdateCustomer", Method.Post) { RequestFormat = DataFormat.Json };
                request.Timeout = int.MaxValue;
                request.AddJsonBody(customer);
                var response = _client.Execute<string>(request);
                if (response.StatusDescription != "OK")
                {
                    var errorObj = ((RestSharp.RestResponseBase)(response));
                    Exception ex = new Exception(errorObj.StatusDescription, new Exception(errorObj.Content));
                    throw ex;
                }
                result = response.Data;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
