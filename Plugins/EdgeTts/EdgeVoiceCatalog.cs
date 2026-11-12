using ApexChatd.Plugins;

namespace ApexChatd.EdgeTts;

internal static class EdgeVoiceCatalog
{
    // Fallback voices from LazySkald's LanguageCatalog.
    public static IReadOnlyList<Voice> Defaults { get; } =
    [
        new("ru-RU-SvetlanaNeural", "Светлана", "ru-RU"), new("ru-RU-DmitryNeural", "Дмитрий", "ru-RU"),
        new("en-US-JennyNeural", "Jenny", "en-US"), new("en-US-GuyNeural", "Guy", "en-US"),
        new("zh-CN-XiaoxiaoNeural", "Xiaoxiao", "zh-CN"), new("zh-CN-YunxiNeural", "Yunxi", "zh-CN"),
        new("ja-JP-NanamiNeural", "Nanami", "ja-JP"), new("ja-JP-KeitaNeural", "Keita", "ja-JP"),
        new("es-ES-ElviraNeural", "Elvira", "es-ES"), new("es-ES-AlvaroNeural", "Alvaro", "es-ES"),
        new("ko-KR-SunHiNeural", "SunHi", "ko-KR"), new("ko-KR-InJoonNeural", "InJoon", "ko-KR"),
        new("fr-FR-DeniseNeural", "Denise", "fr-FR"), new("fr-FR-HenriNeural", "Henri", "fr-FR"),
        new("de-DE-KatjaNeural", "Katja", "de-DE"), new("de-DE-ConradNeural", "Conrad", "de-DE")
    ];

}
