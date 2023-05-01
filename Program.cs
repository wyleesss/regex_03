using System.Text.RegularExpressions;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Regex regex = new(@"^[a-zA-Z0-9!#$%&'+/=?^_`{|}~.-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)$");

        Console.Write("програма перевіряє на правильність електронні адреси у файлі\n" +
                      "(!) у файлі кожна ел. адреса повинна починатися з нового рядка\n\n" +
                      "введіть шлях до файлу:\n=> "); // файл з деякими ел. адресами "data.txt" знаходиться за розташуванням "regex_03\bin\Debug\net7.0"
        try                                           // якщо такого файла немає, створіть будь-який інший та вкажіть його розташування
        {
            using (StreamReader fileStream = new(new string(Console.ReadLine())))
            {
                Console.Clear();
                Console.WriteLine("допустимі адреси:\n");

                string? read;

                while ((read = fileStream.ReadLine()) != null)
                {
                    if (regex.IsMatch(read))
                        Console.WriteLine(read);
                }

                fileStream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}