// See https://aka.ms/new-console-template for more information
using Avengers.Benchmark;
using BenchmarkDotNet.Running;

Console.WriteLine("Benchmark Avenger");

var sumary= BenchmarkRunner.Run<AvengerBenchmark>();
Console.WriteLine("Benchmark Avenger");
Console.ReadLine();