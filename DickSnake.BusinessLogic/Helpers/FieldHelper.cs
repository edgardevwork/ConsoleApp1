using DickSnake.BusinessLogic.IniFiles;

public class FieldHelper
{
    public static (int width, int height) checkSize()
    {
        IniFile iniFile = new IniFile("edgar.ini");
        if (iniFile != null)
        {
            string polyW = iniFile.ReadINI("poly", "w");
            string polyH = iniFile.ReadINI("poly", "h");

            if (string.IsNullOrEmpty(polyW) && string.IsNullOrEmpty(polyH)) // Проверка на пустоту строки
            {
                throw new ArgumentException("Poly: w or h = null!");
            }
            else
            {
                Console.SetWindowSize(int.Parse(polyW), int.Parse(polyH));
                return (int.Parse(polyW), int.Parse(polyH));
            }
        }
        else
        {
            throw new ArgumentException("Poly: w or h = null!");
            //Console.WriteLine("Error w*h!");
        }
    }
}
