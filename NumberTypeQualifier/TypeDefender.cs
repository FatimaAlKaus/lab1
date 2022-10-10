namespace NumberTypeQualifier
{
    static public class TypeDefender
    {
        public const string Type1 = "тип1";
        public const string Type2 = "тип2";
        public const string Type3 = "тип3";
        public const string Type4 = "тип4";
        public const string Type5 = "тип5";

        public static string DetermineType(int number)
        {
            //1
            if (number <= 0 || number % 2 == 0)
            {
                throw new ArgumentException("Число должно быть натуральным и нечетным");//2
            }

            //3
            var types = new List<string>();
            var funcs = new Dictionary<Predicate<int>, string>() //4
            {
                { IsType1, Type1 },
                { IsType2, Type2 },
                { IsType3, Type3 },
                { IsType4, Type4 },
                { IsType5, Type5 },
            };

            foreach (var func in funcs.Keys) //5
            {
                if (func(number)) // 6
                {
                    types.Add(funcs[func]); //7
                }
            } //8

            return string.Join(" и ", types); //9
        }

        //First form
        private static bool IsType1(int number) => (number - 3) % 4 == 0;
        private static bool IsType2(int number) => (number - 5) % 4 == 0;

        //Second form                                                    
        private static bool IsType3(int number) => (number - 3) % 6 == 0;
        private static bool IsType4(int number) => (number - 5) % 6 == 0;
        private static bool IsType5(int number) => (number - 7) % 6 == 0;
    }
}