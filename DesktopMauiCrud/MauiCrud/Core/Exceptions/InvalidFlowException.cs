using System.Diagnostics.CodeAnalysis;

namespace DesktopMauiCrud.MauiCrud.Core.Exceptions
{
    internal class InvalidFlowException : CustomException
    {
        protected InvalidFlowException(string message) : base(message)
        {
        }

        [DoesNotReturn]
        public static void Raise()
        {
            throw new InvalidFlowException("Invalid flow exception");
        }
    }
}
