using LiveLife.Debugging;

namespace LiveLife
{
    public class LiveLifeConsts
    {
        public const string LocalizationSourceName = "LiveLife";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "52596866203a4aad8bc02d0e5ee4422a";
    }
}
