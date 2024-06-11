namespace Blog.ConfigureAspNetCore.Components.Repo
{
    public interface ITheRepo
    {
        int AddNumbers(params int[] numbers);
    }

    public sealed class TheRepo : ITheRepo
    {
        public int AddNumbers(params int[] numbers)
        {
            int result = 0;

            foreach (int nr in numbers) 
            {
                result += nr;
            }

            return result;
        }
    }
}
