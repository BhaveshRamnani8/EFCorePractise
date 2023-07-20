using EFCorePractise.Manager;
using EFCorePractise.Models;
using System.Diagnostics.Metrics;

internal class Program
{
    
    private static void Main(string[] args)
    {
        var operation = new CRUDOperations();
        operation.InsertData();
        operation.UpdateData();
        operation.ReadData();
        operation.RemoveData();
    }
}