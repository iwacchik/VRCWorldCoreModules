
using UdonSharp;
using VRC.SDKBase;

namespace IwacchiLab.Utils
{
    public static class PersistenceUtility
    {
        /// <summary>
        /// 指定されたプレイヤーオブジェクトから指定のスクリプト型 <typeparamref name="T"/> を持つ最初のスクリプトを検索して返します
        /// </summary>
        /// <typeparam name="T">検索するスクリプトの型</typeparam>
        /// <param name="player">検索対象のプレイヤー</param>
        /// <returns>見つかったスクリプトのインスタンス、見つからなければ null</returns>
        public static T FindPlayerObjectScript<T>(VRCPlayerApi player) where T : UdonSharpBehaviour
        {
            var objects = Networking.GetPlayerObjects(player);
            for (int i = 0; i < objects.Length; i++)
            {
                if (Utilities.IsValid(objects[i]))
                {
                    var foundScript = objects[i].GetComponentInChildren<T>();
                    if (Utilities.IsValid(foundScript))
                    {
                        return foundScript;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 指定されたプレイヤーオブジェクトから指定のスクリプト型 <typeparamref name="T"/> を持つすべてのスクリプトを検索して返します
        /// </summary>
        /// <typeparam name="T">検索するスクリプトの型</typeparam>
        /// <param name="player">検索対象のプレイヤー</param>
        /// <returns>見つかったスクリプトの配列、見つからなければ null</returns>
        public static T[] FindPlayerObjectScripts<T>(VRCPlayerApi player) where T : UdonSharpBehaviour
        {
            var objects = Networking.GetPlayerObjects(player);
            for (int i = 0; i < objects.Length; i++)
            {
                if (Utilities.IsValid(objects[i]))
                {
                    var foundScript = objects[i].GetComponentsInChildren<T>();
                    if (Utilities.IsValid(foundScript) && foundScript.Length > 0)
                    {
                        return foundScript;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 指定されたプレイヤーオブジェクトから指定のスクリプト型 <typeparamref name="T"/> を持つ最初のスクリプトを検索し、成功した場合は <paramref name="script"/> に設定します
        /// </summary>
        /// <typeparam name="T">検索するスクリプトの型</typeparam>
        /// <param name="player">検索対象のプレイヤー</param>
        /// <param name="script">見つかったスクリプトのインスタンス</param>
        /// <returns>スクリプトが見つかった場合は true、それ以外は false</returns>
        public static bool TryFindPlayerObjectScript<T>(VRCPlayerApi player, out T script) where T : UdonSharpBehaviour
        {
            script = FindPlayerObjectScript<T>(player);
            return Utilities.IsValid(script);
        }

        /// <summary>
        /// 指定されたプレイヤーオブジェクトから指定のスクリプト型 <typeparamref name="T"/> を持つすべてのスクリプトを検索し、成功した場合は <paramref name="script"/> に設定します
        /// </summary>
        /// <typeparam name="T">検索するスクリプトの型</typeparam>
        /// <param name="player">検索対象のプレイヤー</param>
        /// <param name="script">見つかったスクリプトの配列</param>
        /// <returns>1つ以上のスクリプトが見つかった場合は true、それ以外は false</returns>
        public static bool TryFindPlayerObjectScripts<T>(VRCPlayerApi player, out T[] script)
            where T : UdonSharpBehaviour
        {
            script = FindPlayerObjectScripts<T>(player);
            return Utilities.IsValid(script) && script.Length > 0;
        }
    }
}