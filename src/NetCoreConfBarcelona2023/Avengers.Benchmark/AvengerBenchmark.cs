using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Benchmark;

public class AvengerBenchmark
{
    private static HttpClient _httpClient;
    [GlobalSetup]
    public void GlobalSetup()
    {
        _httpClient = new HttpClient();
    }

    [Benchmark]
    public async Task<bool> GrpcGetallMethod()
    {
        
        var result = await _httpClient.GetFromJsonAsync<dynamic>("https://localhost:7233/api/grpc");
        return true;
        
    }
    [Benchmark]
    public  async Task<bool> GrpcGetByIdMethod()
    {        
        var result = await _httpClient.GetFromJsonAsync<dynamic>("https://localhost:7233/api/grpc/11");
        return true;
    }
    [Benchmark]
    public async Task<bool> RestGetallMethod()
    {
        var result = await _httpClient.GetFromJsonAsync<dynamic>("https://localhost:7233/api/rest/");
        return true;
    }
    [Benchmark]
    public async Task<bool> RestGetByIdMethod()
    {
        var result = await _httpClient.GetFromJsonAsync<dynamic>("https://localhost:7233/api/rest/11");
        return true;
    }
}
