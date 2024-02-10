// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostgresqlGemini.Application;
using PostgresqlGemini.Infrastructure;
using PostgresqlGemini.TestConsole; 

var serviceCollection = new ServiceCollection();

var builder = Host.CreateApplicationBuilder();

serviceCollection.AddApplication();
serviceCollection.AddInfrastructure(builder.Configuration);
serviceCollection.AddTransient<BackgroundInserter>();

var serviceProvider = serviceCollection.BuildServiceProvider();
//var backgroundInserter = serviceProvider.GetRequiredService<BackgroundInserter>();
//await backgroundInserter.AddRecordsAsync(30000);

//yapılacak test senaryoları:
//1- Bir kayıt aynı anda iki kere update edilmeye çalışılmalı:ozan
//2- Transaction yönetimiyle ilgili kayıt ekleme update etme kısımları çıkarılmalı: yakup
//3- json tipleri gibi özel tipler de poc ye dahil edilmeli. buğra

//await Task.Delay(4000);
//var testManager = new TestManager();

//Console.WriteLine("StartInsertAsync started");
////50k create işlemi 00:04:48.1345898 | 4dk.
//Task postTask =  testManager.StartInsertAsync(50000);
//Console.WriteLine("GetTestDataAsync started");

//Task getTask = testManager.GetTestDataAsync();

////daha sonra devam edilecek
////Task getReportTask = testManager.GetTestDataReportAsync();


//await Task.WhenAll(postTask, getTask/*, getReportTask*/);