using System;


namespace DataStructures.Helpers
{
    public static class Guard
    {
        /// <summary>
        /// method to to check Null or Empty
        /// </summary>
        /// <param name="argumentValue"></param>
        /// <param name="argumentName"></param>
        public static void ArgumentNotNullorEmpty(object argumentValue, string argumentName)
        {
            if (IsNull(argumentValue))
            {

                throw new ArgumentNullException(argumentName);

            }
        }
        /// <summary>
        /// method to check if an object is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsNull(object value)
        {
            var stringValue = value as string;
            bool isNull = false;

            if (stringValue != null)
            {
                if (string.IsNullOrEmpty(stringValue))
                {
                    return true;

                }
                switch (stringValue.Trim().Length)
                {
                    case 0:
                        {
                            isNull = true;
                            break;

                        }
                    default:
                        {
                            isNull = false;
                            break;

                        }
                }
                return isNull;
            }


            return value == null;
        }

    }

}
