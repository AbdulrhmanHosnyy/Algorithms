namespace CelebrityPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] persons = { "Ahmed", "Abdo", "Omar", "Adel", "Youssef", "Ali" };
            string currentPerson = persons[0];
            GetAdel(persons, 1, currentPerson);
        }
        static void GetAdel(string[] persons, int Idx, string currentPerson)
        {
            if (Idx > persons.Length - 1)
            {
                Console.WriteLine("Adel index is: " + Array.IndexOf(persons, currentPerson));
                return;
            }
            Console.WriteLine($"{currentPerson} knows {persons[Idx]}?");
            bool answer = Convert.ToBoolean(Console.ReadLine());
            if (answer)
            {
                GetAdel(persons, Idx + 1, persons[Idx]);
            }
            else
            {
                GetAdel(persons, Idx + 1, currentPerson);
            }
        }
    }
}