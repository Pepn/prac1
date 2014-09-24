using System;

namespace Practicum1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        static Practicum1 game = new Practicum1();

        static void Main(string[] args)
        {
            game.Run();
        }

        public static Practicum1 Game
        {
            get { return game; }
        }
        
    }
#endif
}

