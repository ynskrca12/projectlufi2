using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projectlufi.Services
{
    public interface IDialogService
    {
        Task Alert(string message);
    }
}
