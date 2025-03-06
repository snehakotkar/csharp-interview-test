using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Text;

namespace csharp_interview_test
{
    public class FileLogger
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
       
            public FileLogger(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            _filePath = filePath;
        }

        public async Task LogAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message} {Environment.NewLine}";

            await _semaphore.WaitAsync();
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, append: true, encoding: Encoding.UTF8))
                {
                    await writer.WriteAsync(logEntry);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
 
    }
}