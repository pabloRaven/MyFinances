﻿using MyFinances.Core.Dtos;
using MyFinances.Core.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances_Xemarin.Services
{
    public class OperationService : IOperationService
    {

        private static readonly HttpClient _httpClient =
            new HttpClient { BaseAddress = new Uri(App.BackendUrl) };
        
        public async Task<DataResponse<int>> AddAsync(OperationDto operation)
        {
            var stringContent = new StringContent(
                JsonConvert.SerializeObject(operation),
                Encoding.UTF8,
                "application/json");

            using (var response = await _httpClient.PostAsync("operation", stringContent))
            {
                var responeContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DataResponse<int>>(responeContent);

            }
        }

        public async Task<Response> UpdateAsync(OperationDto operation)
        {
            var stringContent = new StringContent(
              JsonConvert.SerializeObject(operation),
              Encoding.UTF8,
              "application/json");

            using (var response =
                await _httpClient.PutAsync("operation", stringContent))
            {
                var responeContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Response>(responeContent);

            }
        }

        public async Task<Response> DeleteAsync(int id)
        {
            using (var response =
                await _httpClient.DeleteAsync($"operation/{ id}"))
            {
                var responeContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Response>(responeContent);

            }
        }

        public async Task<DataResponse<OperationDto>> GetAsync(int id)
        {
            var json = await _httpClient.GetStringAsync($"operation/{ id}");

            return JsonConvert.DeserializeObject<DataResponse<OperationDto>>(json);
        }

        public async Task<DataResponse<IEnumerable<OperationDto>>> GetIAsync(bool forceRefresh = false)
        {
            var json = await _httpClient.GetStringAsync($"operation/");

            return JsonConvert.DeserializeObject<DataResponse<IEnumerable<OperationDto>>>(json);
        }

        public Task<DataResponse<IEnumerable<OperationDto>>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}