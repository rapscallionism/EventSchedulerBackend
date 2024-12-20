using Microsoft.AspNetCore.Mvc;

namespace backend.Utils
{
    public class UsefulUtils
    {
        public static void assertCondition(bool condition)
        {
            try
            {
                if (condition) { return; }
                throw new Exception("Assertion of the condition failed.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
