using backend.Services.Interfaces;

namespace backend.Services
{
    public class MontyHallService : IMontyHallService
    {
        public double GetWinningChance(int gameMode, int gameCount)
        {
            Random random = new Random();
            var wins = 0;
            bool doSwitch = gameMode == 1 ? true : false;

            for(int i = 0; i < gameCount; i++)
            {
                int prizeDoor = random.Next(0, 3);
                int chosenDoor = random.Next(0, 3);
                bool isWin = RunGame(prizeDoor, chosenDoor, doSwitch);

                if (isWin) wins++;

            }

            return ((double)wins/gameCount)*100;
        }

        private bool RunGame(int prizeDoor, int chosenDoor, bool doSwitch)
        {
            List<int> totalDoors = new List<int> {0,1,2};

            if (doSwitch)
            {
                var openedDoor = totalDoors.FirstOrDefault(i=> i!=prizeDoor && i!=chosenDoor);
                chosenDoor = totalDoors.FirstOrDefault(i=> i!=chosenDoor && i!=openedDoor);
            }

            if (prizeDoor == chosenDoor)
            {
                return true;
            }

            return false;
        }
    }
}
