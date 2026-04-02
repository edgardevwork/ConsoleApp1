using DickSnake.BusinessLogic.IniFiles;

public class FieldHelper
{
    public static void checkSize(int gridWidth, int gridHeight)
    {
        IniFile iniFile = new IniFile("edgar.ini");
        if (iniFile != null)
        {
            string polyW = iniFile.ReadINI("poly", "w");
            string polyH = iniFile.ReadINI("poly", "h");

            if (string.IsNullOrEmpty(polyW) && string.IsNullOrEmpty(polyH)) // Проверка на пустоту строки
            {
                //throw new ArgumentException("Poly: w or h = null!");
            }
            else
            {
                gridWidth = int.Parse(polyW);
                gridHeight = int.Parse(polyH);
                Console.SetWindowSize(gridWidth, gridHeight);
            }
        }
        else
        {
            //Console.WriteLine("Error w*h!");
        }
    }
}
