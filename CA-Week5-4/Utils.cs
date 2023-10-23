using CA_Week5_4.clss;
using CA_Week5_4.Exps;
using System;

namespace CA_Week5_4
{
    internal class Utils
    {
        public static void PushEmployee(ref Employee[] arr, Employee e)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[^1] = e;
        }

        public static void RemoveEmployee(ref Employee[] arr, int id)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Id == id)
                {
                    (arr[i], arr[^1]) = (arr[^1], arr[i]);
                    Array.Resize(ref arr, arr.Length - 1);

                    return;
                }
   
            }

            throw new NoValidEmployeeException("There is no such valid Employee - id: " + id);

        }
    }
}
