using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PCLStorage;
using Newtonsoft.Json;

namespace PakaPakaCalc.Models
{
    public class GameModel
    {
        private const string FILE_SETTING = "app.settings";
        private const string DIR_SETTING = "settings";

        private static GameModel _instance = null;
        public static GameModel Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new GameModel();
                }

                return _instance;
            }
        }

        private GameModel()
        {
        }

        public GameSettings Settings  
        {
            get;
            private set;
        }

        private readonly List<int[]> _numbersList = new List<int[]>();
        private List<int> _answerList;
        private readonly List<int> _correctAnswerList = new List<int>();

        public Task BuildGame(GameSettings settings) 
        {
            this.Settings = settings;

            _answerList = Enumerable.Repeat(0, settings.Nums).ToList();
            _numbersList.Clear();
            _correctAnswerList.Clear();
            var rand = new Random();
            for (int i = 0; i < settings.Nums; i++)
            {
                var nums = Enumerable.Range(0, settings.Times)
                    .Select(_ =>
                {
                        Predicate<int> shouldContinue = x => 
                        {
                            if (x == 0) {
                                return true;
                            }
                            else if (x < (int)Math.Pow(10, settings.Digits - 1)) 
                            {
                                return true;
                            }

                            return false;
                        };

                    int n;
                    while (shouldContinue(n = rand.Next((int)Math.Pow(10, settings.Digits))))
                    {
                    }
                    return n;
                });
                var arrNums = nums.ToArray();
                _numbersList.Add(arrNums);
                _correctAnswerList.Add(arrNums.Sum());
            }

            return SaveSettings(settings);
        }

        public async Task SaveSettings(GameSettings settings)
        {
            IFolder root = FileSystem.Current.LocalStorage;
            IFolder folder = await root.CreateFolderAsync(DIR_SETTING,
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(FILE_SETTING,
                CreationCollisionOption.ReplaceExisting);

            string json = JsonConvert.SerializeObject(settings);

            await file.WriteAllTextAsync(json);
        }

        public async Task<GameSettings> LoadSettings()
        {

            IFolder root = FileSystem.Current.LocalStorage;
            if (await root.CheckExistsAsync(DIR_SETTING) == ExistenceCheckResult.NotFound)
            {
                return null;
            }

            IFolder folder = await root.GetFolderAsync(DIR_SETTING);
            if (await folder.CheckExistsAsync(FILE_SETTING) == ExistenceCheckResult.NotFound)
            {
                return null;
            }

            var file = await folder.GetFileAsync(FILE_SETTING);
            var json = await file.ReadAllTextAsync();

            return JsonConvert.DeserializeObject<GameSettings>(json);
        }

        public int[] GetNumbers(int indexOfQuestions)
        {
            return _numbersList[indexOfQuestions];
        }

        public bool SetAnswer(int indexOfQuestions, int answer)
        {
            var correct = _correctAnswerList[indexOfQuestions] == answer;
            _answerList[indexOfQuestions] = answer;

            return correct;
        }

        public int GetAnswer(int indexOfQuestions)
        {
            return _answerList[indexOfQuestions];
        }

        public int GetCollectAnswer(int indexOfQuestions)
        {
            return _correctAnswerList[indexOfQuestions];
        }
    }
}

