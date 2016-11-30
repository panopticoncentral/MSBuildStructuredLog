﻿using System;
using System.Windows.Input;

namespace Microsoft.Build.Logging.StructuredLogger
{
    public class BuildParametersScreen : ObservableObject
    {
        public event Action BuildRequested;
        public event Action CancelRequested;

        private string prefixArguments;
        public string PrefixArguments
        {
            get
            {
                return prefixArguments;
            }

            set
            {
                prefixArguments = value;
                RaisePropertyChanged();
            }
        }

        public string MSBuildArguments { get; set; }
        public string PostfixArguments { get; set; }

        private ICommand buildCommand;
        public ICommand BuildCommand => buildCommand ?? (buildCommand = new Command(Build));
        private void Build() => BuildRequested?.Invoke();

        private ICommand cancelCommand;
        public ICommand CancelCommand => cancelCommand ?? (cancelCommand = new Command(Cancel));
        private void Cancel() => CancelRequested?.Invoke();
    }
}