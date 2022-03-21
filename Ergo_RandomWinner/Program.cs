namespace Ergo_RandomWinner
{
    class Program
    {
        static void Main(string[] args)
        {
            var FilePath = Logic.GetFilePath();
            Logic.Validator.ValidateFilePath(FilePath);

            var ContenderList = Logic.PopulateContenderList(FilePath);
            var isValidContenderList = Logic.Validator.ValidateContenderList(ContenderList);
            if (isValidContenderList == false) return;

            var NumberOfWinners = Logic.GetNumberOfWinners();
            bool IsNumberOfWinnersValid = Logic.Validator.ValidateNumberOfWinners(NumberOfWinners, ContenderList.Count);
            if (IsNumberOfWinnersValid == false) return;

            var WinnerList = Logic.PickRandom(ContenderList, NumberOfWinners);

            var IsWinnerCountValid = Logic.Validator.ValidateWinnerList(ContenderList);
            if (IsWinnerCountValid) Logic.Announcement.AnnounceWinners(WinnerList);
        }
    }
}
