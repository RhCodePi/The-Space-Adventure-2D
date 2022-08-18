using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rhcodepi
{
    public static class SaveData
    {

        public static string standard = "standard";
        public static string challenge = "challenge";
        public static string easy = "easy";
        public static string normal = "normal";
        public static string hard = "hard";
        public static string easyPuan = "easyPuan";
        public static string normalPuan = "normalPuan";
        public static string hardPuan = "hardPuan";
        public static string easyCoin = "easyCoin";
        public static string normalCoin = "normalCoin";
        public static string hardCoin = "hardCoin";

        public static string music = "music";

        #region SaveSettings
        public static void SetSaveEasy(int value)
        {
            PlayerPrefs.SetInt(easy, value);
        }
        public static int GetSaveEasy()
        {
            return PlayerPrefs.GetInt(easy);
        }

        public static void SetSaveNormal(int value)
        {
            PlayerPrefs.SetInt(normal, value);
        }
        public static int GetSaveNormal()
        {
            return PlayerPrefs.GetInt(normal);
        }

        public static void SetSaveHard(int value)
        {
            PlayerPrefs.SetInt(hard, value);
        }
        public static int GetSaveHard()
        {
            return PlayerPrefs.GetInt(hard);
        }
        #endregion

        #region  SavePuan
        public static void SetSaveEasyPuan(int value)
        {
            PlayerPrefs.SetInt(easyPuan, value);
        }
        public static int GetSaveEasyPuan()
        {
            return PlayerPrefs.GetInt(easyPuan);
        }

        public static void SetSaveNormalPuan(int value)
        {
            PlayerPrefs.SetInt(normalPuan, value);
        }
        public static int GetSaveNormalPuan()
        {
            return PlayerPrefs.GetInt(normalPuan);
        }

        public static void SetSaveHardPuan(int value)
        {
            PlayerPrefs.SetInt(hardPuan, value);
        }
        public static int GetSaveHardPuan()
        {
            return PlayerPrefs.GetInt(hardPuan);
        }
        #endregion

        #region SaveCoin
        public static void SetSaveEasyCoin(int value)
        {
            PlayerPrefs.SetInt(easyCoin, value);
        }
        public static int GetSaveEasyCoin()
        {
            return PlayerPrefs.GetInt(easyCoin);
        }

        public static void SetSaveNormalCoin(int value)
        {
            PlayerPrefs.SetInt(normalCoin, value);
        }
        public static int GetSaveNormalCoin()
        {
            return PlayerPrefs.GetInt(normalCoin);
        }

        public static void SetSaveHardCoin(int value)
        {
            PlayerPrefs.SetInt(hardCoin, value);
        }
        public static int GetSaveHardCoin()
        {
            return PlayerPrefs.GetInt(hardCoin);
        }
        #endregion

        #region SaveMusic
        public static void SetSaveMusic(int value)
        {
            PlayerPrefs.SetInt(music, value);
        }
        public static int GetMusic()
        {
            return PlayerPrefs.GetInt(music);
        }
        #endregion

        #region SaveStandard
        public static void SetSaveStandard(int value)
        {
            PlayerPrefs.SetInt(standard, value);
        }

        public static int GetStandard()
        {
            return PlayerPrefs.GetInt(standard);
        }

        #endregion

        #region SaveChallenge
        public static void SetSaveChallenge(int value)
        {
            PlayerPrefs.SetInt(challenge, value);
        }

        public static int GetChallenge()
        {
            return PlayerPrefs.GetInt(challenge);
        }


        #endregion
        public static bool isDataOnPrefs()
        {
            if (PlayerPrefs.HasKey(easy) || PlayerPrefs.HasKey(normal) || PlayerPrefs.HasKey(hard))
                return true;
            else
                return false;
        }
        public static bool isModeOnPrefs()
        {
            if(PlayerPrefs.HasKey(standard) || PlayerPrefs.HasKey(challenge))
                return true;
            else 
                return false;
        }
        public static bool isMusicOnPrefs()
        {
            if (PlayerPrefs.HasKey(music))
                return true;
            else
                return false;
        }
    }
}

