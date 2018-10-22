using Newtonsoft.Json;
using SWriter.RequestManager.Translation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SWriter.RequestManager
{
    public enum ContentType
    {
        JSON,
        XML,
        FORM
    }

    public class RequestSender
    {
        private static Dictionary<string, HttpClient> _CLIENTS;

        private HttpClient _client;

        public RequestSender(string baseURI)
        {
            var value = _CLIENTS.GetValueOrDefault(baseURI);
            if (value == null)
            {
                var newClient = new HttpClient();
                newClient.BaseAddress = new Uri(baseURI);
                _CLIENTS.Add(baseURI, newClient);
                _client = newClient;
            }
            else
            {
                _client = _CLIENTS.GetValueOrDefault(baseURI);
            }
        }

        public RequestSender(HttpClient client)
        {
            var value = _CLIENTS.GetValueOrDefault(client.BaseAddress.AbsoluteUri);
            if (value == null)
            {
                _CLIENTS.Add(client.BaseAddress.AbsoluteUri, client);
                _client = client;
            }
            _client = client;
        }

        public async Task<Response> GetAsync(string path)
        {
            var httpResponse = await _client.GetAsync(path);

            var response = new Response() { Success = httpResponse.IsSuccessStatusCode, Content = await httpResponse.Content.ReadAsStringAsync() };

            return response;
        }

        public async Task<Response> PostAsync<T>(string path, T content, ContentType type = ContentType.JSON)
        {
            var postContent = SerializeToStringContent(content, type);
            var httpResponse = await _client.PostAsync(path, postContent);
            var response = new Response() { Success = httpResponse.IsSuccessStatusCode, Content = await httpResponse.Content.ReadAsStringAsync() };

            return response;
        }

        public async Task<Response> PutAsync<T>(string path, T content, ContentType type = ContentType.JSON)
        {
            var putContent = SerializeToStringContent(content, type);
            var httpResponse = await _client.PutAsync(path, putContent);
            var response = new Response() { Success = httpResponse.IsSuccessStatusCode, Content = await httpResponse.Content.ReadAsStringAsync() };

            return response;
        }

        public async Task<Response> PatchAsync<T>(string path, T content, ContentType type = ContentType.JSON)
        {
            var patchContent = SerializeToStringContent(content, type);
            var httpResponse = await _client.PatchAsync(path, patchContent);
            var response = new Response() { Success = httpResponse.IsSuccessStatusCode, Content = await httpResponse.Content.ReadAsStringAsync() };

            return response;
        }

        public async Task<Response> DeleteAsync(string path)
        {
            var httpResponse = await _client.DeleteAsync(path);

            var response = new Response() { Success = httpResponse.IsSuccessStatusCode, Content = await httpResponse.Content.ReadAsStringAsync() };

            return response;
        }

        public async Task<Response> SendRequestAsync(string method, string path, object content = null)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = new HttpMethod(method),
                RequestUri = new Uri(_client.BaseAddress.AbsoluteUri + path),
                Content = new StringContent(JsonConvert.SerializeObject(content))
            };

            var httpResponse = await _client.SendAsync(request);

            var response = new Response() { Success = httpResponse.IsSuccessStatusCode, Content = await httpResponse.Content.ReadAsStringAsync() };

            return response;
        }

        private StringContent SerializeToStringContent<T>(T content, ContentType type)
        {
            return TranslatorFactory.GetTranslator<T>(type)
                                    .SerializeFrom(content)
                                    .ToStringContent();
        }
    }
}
