using System.Management;

namespace MARGO
{
    public class SecurityManager
    {
        public long GetSerial()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            string mac = "";
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();

            }
            mc.Dispose();

            long sum = 0;
            int index = 1;

            foreach (char ch in mac)
            {
                if (char.IsDigit(ch))
                { sum += sum + ((int)ch) * (index * 2); }
                else if (char.IsLetter(ch))
                {
                    switch (ch.ToString().ToUpper())
                    {
                        case "A":
                            sum += sum + 10 * (index * 2);
                            break;
                        case "B":
                            sum += sum + 11 * (index * 2);
                            break;
                        case "C":
                            sum += sum + 12 * (index * 2);
                            break;
                        case "D":
                            sum += sum + 13 * (index * 2);
                            break;
                        case "E":
                            sum += sum + 14 * (index * 2);
                            break;
                        case "F":
                            sum += sum + 15 * (index * 2);
                            break;
                    }
                }
                index += 1;
            }
            return sum;
        }

        public bool CheckKey(long key)
        {
            long x = GetSerial();
            long y = x * x + 53 / x + 113 * (x / 4);
            if (y == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}