﻿using NeatInput.Windows.Events;
using NeatInput.Windows.Win32.Enums;

using System.Collections.Generic;

namespace NeatInput.Windows.Processing
{
    internal abstract class InputProcessor<TInput, TOutput>
        where TInput : struct
        where TOutput : InputEvent, new()
    {
        protected List<IProcessingStep<TInput, TOutput>> ProcessingSteps = 
            new List<IProcessingStep<TInput, TOutput>>();

        internal TOutput Transform(WindowsMessages message, TInput input)
        {
            var valueTransformation = new ValueTransformation<TInput, TOutput>()
            {
                Message = message,
                Input = input,
                Output = new TOutput()
            };

            foreach (var step in ProcessingSteps)
                valueTransformation = step.Process(valueTransformation);

            return valueTransformation.Output;
        }
    }
}
