
using AgendaProTela.Api.Models;
using AgendaProTela.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgendaProTela
{
    internal class AgendaProApiClient
    {
        static HttpClient client = new HttpClient();


        public async Task<List<Contact>> GetContactsAsync()
        {
            string url = "https://localhost:7119/v1/contact";

            try
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        List<Contact> contatos = JsonSerializer.Deserialize<List<Contact>>(content, options);

                        return contatos;

                    }
                    else
                    {
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível obter visualizar a lista de contatos" + ex.Message);

            }

        }

        public async Task<Contact> GetContactsByIdAsync(string matricula)
        {
            Contact contato = null;

            try

            {
                if (!int.TryParse(matricula, out int Id))
                {
                    MessageBox.Show("Matrícula inválida.");
                    return null;
                }

                string url = $"https://localhost:7119/v1/contact/{Id}";

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        return JsonSerializer.Deserialize<Contact>(content, options);


                    }

                    else
                    {
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                return null;


            }

        }

        public async Task<Contact> PostContactAsync(string name, string email, string phone)
        {
            string url = "https://localhost:7119/v1/contact";

            try
            {
                Contact data = new Contact
                {
                    Name = name,
                    Email = email,
                    Phone = phone
                };


                using (HttpResponseMessage response = client.PostAsJsonAsync(url, data).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsStringAsync().Result;

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        return JsonSerializer.Deserialize<Contact>(responseBody, options);

                    }

                    else if ((int)response.StatusCode >= 400 && (int)response.StatusCode <= 499)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        var error = JsonSerializer.Deserialize<ApiErro>(content, options);

                        var message = "";

                        foreach (var erro in error.Errors)
                        {
                            message += $"{erro.Key}: \n" ;


                            foreach (var item in erro.Value)
                            {
                                message = $"{message + item} \n \n";

                            }

                        }

                        MessageBox.Show(message,
                            "Erro",
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);

                        return null;

                    }

                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<bool> UpdateAsync(string matricula, string name, string email, string phone)
        {


            try
            {
                if (!int.TryParse(matricula, out int Id))
                {
                    MessageBox.Show("Matrícula inválida.");
                    return false;
                }

                string url = $"https://localhost:7119/v1/contact/{Id}";

                var contato = GetContactsByIdAsync(matricula).Result;

                if (contato == null)
                {
                    MessageBox.Show("Contato não encontrado");
                    return false;
                }

                if (!string.IsNullOrEmpty(name))
                {
                    contato.Name = name;
                }

                if (!string.IsNullOrEmpty(email))
                {
                    contato.Email = email;
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    contato.Phone = phone;
                }


                using (HttpResponseMessage response = client.PutAsJsonAsync(url, contato).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    else if ((int)response.StatusCode >= 400 && (int)response.StatusCode >= 499)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        var error = JsonSerializer.Deserialize<ApiErro>(content, options);

                        var message = "";

                        foreach (var erro in error.Errors)
                        {
                            message += $"{erro.Key}: \n";


                            foreach (var item in erro.Value)
                            {
                                message = $"{message + item} \n \n";

                            }

                        }

                        MessageBox.Show(message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);


                        return false;

                    }

                    else
                    {

                        return false;
                    }

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o contato: " + ex.Message);
                return false;

            }
        }


        public async Task<bool> DeleteAsync(string matricula)
        {
            try
            {
                if (!int.TryParse(matricula, out int Id))
                {
                    MessageBox.Show("Matrícula inválida.");
                    return false;
                }

                string url = $"https://localhost:7119/v1/contact/{Id}";

                using (HttpResponseMessage response = client.DeleteAsync(url).Result)
                {

                    return response.IsSuccessStatusCode;

                }
            }
            catch (Exception ex)
            {

                return false;

            }

        }
    }


}



