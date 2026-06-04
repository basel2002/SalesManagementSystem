using CodeFirst.Context;
using System;

namespace ProjectForm
{
    /// <summary>
    /// Helper class to manage DbContext lifecycle in WinForms application.
    /// Provides a single shared instance to prevent memory leaks from multiple contexts.
    /// </summary>
    public static class DbContextHelper
    {
        private static MyContext? _context;
        private static readonly object _lockObject = new object();

        /// <summary>
        /// Gets or creates a shared DbContext instance.
        /// </summary>
        public static MyContext GetContext()
        {
            if (_context == null)
            {
                lock (_lockObject)
                {
                    if (_context == null)
                    {
                        _context = new MyContext();
                    }
                }
            }
            return _context;
        }

        /// <summary>
        /// Disposes the shared DbContext instance.
        /// Should be called when the application is closing.
        /// </summary>
        public static void DisposeContext()
        {
            if (_context != null)
            {
                lock (_lockObject)
                {
                    _context?.Dispose();
                    _context = null;
                }
            }
        }

        /// <summary>
        /// Resets the context (useful for testing or forcing a fresh context).
        /// </summary>
        public static void ResetContext()
        {
            DisposeContext();
        }
    }
}
