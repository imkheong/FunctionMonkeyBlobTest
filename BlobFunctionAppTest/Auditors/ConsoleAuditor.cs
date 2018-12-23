using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFromTheTrenches.Commanding.Abstractions.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlobFunctionAppTest.Auditors
{
    public class ConsoleAuditor : ICommandAuditor
    {
        public Task Audit(AuditItem item, CancellationToken cancellationToken)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Type: {item.CommandTypeFullName}");
            Console.WriteLine($"Correlation ID: {item.CorrelationId}");
            Console.WriteLine($"Depth: {item.Depth}");
            foreach (KeyValuePair<string, string> enrichedProperty in item.AdditionalProperties)
            {
                Console.WriteLine($"{enrichedProperty.Key}: {enrichedProperty.Value}");
            }
            Console.ForegroundColor = previousColor;
            return Task.FromResult(0);
        }
    }
}
