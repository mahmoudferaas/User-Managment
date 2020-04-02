using System;
using System.Linq.Expressions;
using Microsoft.Extensions.Localization;

namespace Users.Service.Managment.Common
{
    public static class LocalizerExtensions
    {
        public static LocalizedString GetString<TKey>(this IStringLocalizer stringLocalizer, Expression<Func<TKey, string>> keyName, SearchLanguages language)
        {
            //try
            //{
            //    var keyNameString = ConfigUtils.GetKeyFullName(keyName);
            //    var baseUrl = _configurationManager.GetConfiguration<B2B.Hotels.Localization, string>(k => k.BaseUrl);
            //    dynamic getLocalizedResponse = await _httpCommunication.GetAsync<object>($"{baseUrl}Localizations/GetLocalizedValue/{keyNameString}/{language}");
            //    return getLocalizedResponse[keyNameString].ToString();
            //}
            //catch (Exception)
            //{
            //    if (keyName is null)
            //    {
            //        return "Default message";
            //    }
            //    var keyNameString = ConfigUtils.GetKeyFullName(keyName);
            //    if (keyNameString is null)
            //    {
            //        return "Default message";
            //    }
            //    return keyNameString;
            //}
            if (keyName.ToString().ToLower().Contains("selectroom"))
            {
                return new LocalizedString("RoomId", "Select a room");
            }
            if (keyName.ToString().ToLower().Contains("countlimits"))
            {
                return new LocalizedString("Count", "Rooms count should be greater than 0 and less than 5");
            }
            return new LocalizedString("NoKey", "No message");
        }
    }

    public enum SearchLanguages
    {
        Ar = 1,
        En = 2,
        Fr = 3
    }
}
