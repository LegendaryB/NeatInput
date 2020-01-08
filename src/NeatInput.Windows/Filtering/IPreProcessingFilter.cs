using NeatInput.Windows.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeatInput.Windows.Filtering
{
    public interface IPreProcessingFilter
    {
        bool PreFilterMessage(Message message);
    }
}
