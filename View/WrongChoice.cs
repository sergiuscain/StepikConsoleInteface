
namespace StepikPetProject.View
{
    public class WrongChoice
    {
        public void PrintWrongChoiceMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            Console.ResetColor();
        }
    }

}
