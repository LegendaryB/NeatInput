using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Keyboard;
using NeatInput.Windows.Processing.Keyboard.Steps;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;

using System.Collections.Generic;

namespace NeatInput.Windows.Processing
{
    internal class KeyboardProcessor
    {
        private List<IProcessingStep> _processingSteps;

        internal KeyboardProcessor()
        {
            _processingSteps = new List<IProcessingStep>
            {
                new PressedKey(),
                new State()
            };
        }

        internal KeyboardEvent Process(WindowsMessages message, KBDLLHOOKSTRUCT @struct)
        {
            var transformation = new ValueWrapper
            {
                Message = message,
                InputStruct = @struct,
                Output = new KeyboardEvent()
            };

            foreach (var step in _processingSteps)
                transformation = step.Process(transformation);

            return transformation.Output;
        }
    }
}
