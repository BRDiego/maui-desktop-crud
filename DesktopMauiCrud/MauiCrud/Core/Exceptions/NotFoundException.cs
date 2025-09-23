using System.Diagnostics.CodeAnalysis;

namespace DesktopMauiCrud.MauiCrud.Core.Exceptions
{
    public class NotFoundException : CustomException
    {
        private NotFoundException(string message) : base(message)
        {
        }

        [DoesNotReturn]
        public static void Raise()
        {
            throw new NotFoundException("Register not found");
        }
    }
}
