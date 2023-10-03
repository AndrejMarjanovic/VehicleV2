using Flurl;
using Flurl.Http;
using System.Net;
using Vehicle.FormUI.Forms;
using Vehicle.Model;

namespace Vehicle.FormUI.API
{
    public class APIService
    {

        public static string? Username { get; set; }
        public static string? Password { get; set; }
        public static UserModel? LoggedUser { get; set; }

        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>()
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiURL}/{_route}";

                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, $"{ex.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }

        }

        public async Task<T> GetFiltered<T>(object searchrequest = null)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiURL}/{_route}/Filtered";


                if (searchrequest != null)
                {
                    url += "?";
                    url = url.SetQueryParams(searchrequest);

                }
                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                throw;
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiURL}/{_route}/{id}";
                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                throw;
            }
        }
        public async Task<T> Insert<T>(object request)
        {
            try
            {

                var url = $"{Properties.Settings.Default.ApiURL}/{_route}";
                var result = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {

                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                throw;
            }
        }
        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiURL}/{_route}/{id}";
                var result = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
                return result;

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                throw;
            }
        }

        public async Task<T> UpdateUser<T>(object id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiURL}/{_route}/EditAdmin/{id}";
                var result = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
                return result;

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                throw;
            }
        }
        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiURL}/{_route}/{id}";
                var result = await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
                return result;

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Invalid user credentials.", "Unauthorized!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("You are not allowed access.", "Forbbiden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                throw;
            }
        }
    }
}