using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zjazd3_sobota_zad_2
{
    public class Program
    {
        // Metoda usuwająca duplikaty z listy
        public static void UsunDuplikaty(List<int> liczby)
        {
            HashSet<int> widziane = new HashSet<int>();
            int indeksZapisu = 0;

            for (int indeksOdczytu = 0; indeksOdczytu < liczby.Count; indeksOdczytu++)
            {
                // Jeżeli liczba nie została jeszcze zapisana, zapisz ją
                if (!widziane.Contains(liczby[indeksOdczytu]))
                {
                    widziane.Add(liczby[indeksOdczytu]);
                    liczby[indeksZapisu] = liczby[indeksOdczytu];
                    indeksZapisu++;
                }
            }

            // Usuń zbędne elementy na końcu listy
            liczby.RemoveRange(indeksZapisu, liczby.Count - indeksZapisu);
        }

        public static void Main()
        {
            // Poproś użytkownika o wprowadzenie listy liczb
            Console.WriteLine("Proszę podać listę liczb całkowitych oddzielonych spacją:");
            string wejscie = Console.ReadLine();

            // Sprawdź czy wejście nie jest puste
            if (string.IsNullOrEmpty(wejscie))
            {
                Console.WriteLine("Nie wprowadzono żadnych liczb. Proszę spróbować ponownie.");
                return;
            }

            List<int> liczby;
            try
            {
                // Przekonwertuj wprowadzony ciąg na listę liczb całkowitych
                liczby = new List<int>(Array.ConvertAll(wejscie.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadzono nieprawidłowe dane. Proszę wprowadzić tylko liczby całkowite.");
                return;
            }

            // Wyświetl listę przed usunięciem duplikatów
            Console.WriteLine("Lista przed wywołaniem metody:");
            Console.WriteLine(string.Join(" ", liczby));

            // Usuń duplikaty
            UsunDuplikaty(liczby);

            // Wyświetl listę po usunięciu duplikatów
            Console.WriteLine("Lista po wywołaniu metody:");
            Console.WriteLine(string.Join(" ", liczby));

            // Dodaj oczekiwanie na wciśnięcie klawisza, aby zobaczyć wyniki w konsoli
            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć.");
            Console.ReadKey();
        }
    }
}
